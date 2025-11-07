using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_Chamados.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API_Chamados.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(Usuario usuario)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var secret = jwtSettings["Secret"] ?? throw new InvalidOperationException("JWT Secret não configurado");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("nome", usuario.Nome),
                new Claim("tipo", usuario.Tipo),
                new Claim("cpf", usuario.Cpf)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
