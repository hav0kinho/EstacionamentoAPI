using AutoMapper;
using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/estacionamentos")]
    [Authorize]
    public class EstacionamentoController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public EstacionamentoController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]

        public IActionResult GetEstacionamentos()
        {
            var estacionamentos = _db.Estacionamentos.Include(x => x.Veiculos).ToList();
            return Ok(estacionamentos);

        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]

        public IActionResult GetEstacionamento(int id)
        {
            var estacionamento = _db.Estacionamentos.Find(id);
            if(estacionamento == null)
            {
                return BadRequest("Estacionamento não existe.");
            }

            return Ok(estacionamento);

        }

        [HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult CreateEstacionamento([FromBody] EstacionamentoDTO estacionamentoDTO)
        {
            var estacionamento = _mapper.Map<Estacionamento>(estacionamentoDTO);

            if(estacionamento == null)
            {
                return BadRequest();
            }

            _db.Estacionamentos.Add(estacionamento);
            _db.SaveChanges();



            return Ok(estacionamento);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public IActionResult DeleteEstacionamento(int id)
        {
            var estacionamento = _db.Estacionamentos.Find(id);

            if(estacionamento == null)
            {
                return BadRequest("Estacionamento não existe.");
            }

            _db.Estacionamentos.Remove(estacionamento);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPost("estacionar-carro/{id}/{placa}")]
        [Authorize(Roles = "user, admin")]

        public async Task<IActionResult> AddCarroInEstacionamento(int id, string placa)
        {
            var estacionamento = _db.Estacionamentos.Find(id);
            var carro = await _db.Carros.FirstOrDefaultAsync(x => x.Placa == placa);

            if(estacionamento == null)
            {
                return NotFound("O estacionamento não foi encontrado.");
            }
            if(carro == null)
            {
                return NotFound("O carro não foi encontrado.");
            }

            var carroComAMesmaPlaca = estacionamento.Veiculos.FirstOrDefault(x => x.Placa == carro.Placa);

            if(carroComAMesmaPlaca != null)
            {
                return BadRequest("O carro já está estacionado");
            }

            estacionamento.Veiculos.Add(carro);


            await _db.SaveChangesAsync();

            return Ok("Veiculo adicionado.");
        }

        [HttpPost("retirar-carro/{id}/{placa}")]

        public async Task<IActionResult> RemoveCarroFromEstacionamento(int id, string placa)
        {
            var estacionamento = await _db.Estacionamentos.FindAsync(id);
            var carro = await _db.Carros.FindAsync(id);

            if (estacionamento == null)
            {
                return NotFound("O estacionamento não foi encontrado.");
            }
            if (carro == null)
            {
                return NotFound("O carro não foi encontrado.");
            }

            

            estacionamento.Veiculos.Remove(carro);
            await _db.SaveChangesAsync();

            return Ok("Veiculo retirado.");
        }
    }
}
