using EstacionamentoAPI.Models;
using EstacionamentoAPI;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EstacionamentoAPI.Services
{
    public class TokenService
    {
        public string Generate(User user)
        {
            // Criar uma instância do JWTSecurityTokenHandler
            var handler = new JwtSecurityTokenHandler();

            var chave = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            var chaveSimetrica = new SymmetricSecurityKey(chave);

            // SigningCredentials(CHAVE, ALGORITMO)
            var credentials = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

            // Informações que estarão no Token.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(2),
            };

            // Gera um Token
            var token = handler.CreateToken(tokenDescriptor);

            // Gera a string do Token
            var strToken = handler.WriteToken(token);

            return strToken;
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            // Cria a coleção de Claims
            var ci = new ClaimsIdentity();

            // Adicionando as claims
            ci.AddClaim(
                new Claim(ClaimTypes.Name, user.Name)
                );

            foreach (var role in user.Roles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            /*
             * No ASP.NET, entre as várias claims que você pode adicionar (fora as que estão no ClaimTypes), existem algumas extremamente importantes e que podem faciltiar várias coisas 
             * que são as: Name e Roles
             * 
             * Com essas claims, alguns processos ficam muito mais fáceis de ser implementandos e alguns dados ficam mais fáceis de serem resgatados!
            */
            // User.Idendity.Name
            // User.IsInRole
            // [Authorize]
            return ci;
        }
    }
}
