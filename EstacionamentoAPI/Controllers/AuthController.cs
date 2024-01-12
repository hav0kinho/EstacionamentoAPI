using AutoMapper;
using EstacionamentoAPI.Data;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Models.DTO;
using EstacionamentoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthController(AppDbContext db, TokenService tokenService, IMapper mapper)
        {
            _db = db;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var usuario = _mapper.Map<User>(userDto);

            usuario.Roles = ["user"];

            await _db.Users.AddAsync(usuario);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("registrar/admin")]
        public async Task<IActionResult> RegisterAdmin(UserDTO userDto)
        {
            var usuario = _mapper.Map<User>(userDto);
            usuario.Roles = ["admin"];

            await _db.Users.AddAsync(usuario);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            var usuario = _mapper.Map<User>(userDto);

            var usuarioRequisitado = await _db.Users.FirstOrDefaultAsync(x => x.Name == usuario.Name);

            if(usuarioRequisitado == null)
            {
                return BadRequest("Usuário não encontrado");
            } 
            else
            {
                if(usuario.Password != usuarioRequisitado.Password)
                {
                    return BadRequest("Senha incorreta");
                }

                var token = _tokenService.Generate(usuarioRequisitado);

                return Ok(token);
            }
        }
    }
}
