using Api_Auth.Dtos;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using static Settings.Variants;
using System.Security.Claims;
using System.Text;

namespace Utils
{
    public class Helper
    {
        public static string GenerateHash(string value)
        {
            // Gera um salt padrão se não for fornecido
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12); // 12 é o work factor padrão
            return BCrypt.Net.BCrypt.HashPassword(value, salt);
        }

        public static TokenDto GenerateToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(SECRET_KEY);
            var tokenHandler = new JwtSecurityTokenHandler();
            var expires = DateTime.UtcNow.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = null, // Implemente se necessário
                AccessTokenExpiration = new DateTimeOffset(expires).ToUnixTimeSeconds()
            };
        }
    }
}
