using AutoMapper;
using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/estacionamentos")]
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
        public IActionResult GetEstacionamentos()
        {
            var estacionamentos = _db.Estacionamentos.Include(x => x.Veiculos).ToList();
            return Ok(estacionamentos);

        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> AddCarroInEstacionamento(int id, string placa)
        {
            var estacionamento = _db.Estacionamentos.Find(id);
            var carro = await _db.Carros.FirstOrDefaultAsync(x => x.Placa == placa);

            estacionamento.Veiculos.Add(carro);


            await _db.SaveChangesAsync();

            return Ok("Veiculo adicionado");
        }
    }
}
