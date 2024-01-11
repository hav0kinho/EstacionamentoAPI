using AutoMapper;
using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/carros")]
    public class CarroController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public CarroController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCarros()
        {
            var carros = _db.Carros.ToList();
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarro(int id)
        {
            var carro = _db.Carros.Find(id);

            if(carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        [HttpGet("buscar-placa/{placa}")]
        public IActionResult GetCarroWithPlaca(string placa)
        {
            var carro = _db.Carros.FirstOrDefault(x => x.Placa == placa);

            if(carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        [HttpPost]
        public IActionResult CreateCarro(CarroDTO carroDto)
        {
            var carro = _mapper.Map<Carro>(carroDto);

            if(carro == null)
            {
                return BadRequest();
            }

            _db.Carros.Add(carro);
            _db.SaveChanges();

            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarro(int id)
        {
            var carro = _db.Carros.Find(id);
            if(carro == null)
            {
                return BadRequest();
            }

            _db.Carros.Remove(carro);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
