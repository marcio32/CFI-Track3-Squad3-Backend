// Clase de utilidad para la generación de tokens JWT

using CFI_Track3_Squad3_Backend.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CFI_Track3_Squad3_Backend.Helper
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration;

        public TokenJwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT para el usuario especificado.
        /// </summary>
        /// <param name="user">Usuario para el cual se genera el token.</param>
        /// <returns>Token JWT generado.</returns>
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(600),
                signingCredentials: credentials
                );

            var response = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return response;
        }
    }
}
