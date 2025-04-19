
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserService.TokenGenerators
{
   
    public class TokenGenerator
    {
        public string GenerateJwtToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("John_ben_2016_padre_263937112??#_HasteOk"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Identificador único del token
            new Claim(ClaimTypes.Role, "Admin") // Puedes agregar roles o permisos aquí
        };

            var token = new JwtSecurityToken(
                issuer: "https://mi-servidor-de-autenticacion.com", // Debe coincidir con el Authority en el API Gateway
                audience: "mi-api", // Debe coincidir con el Audience en el API Gateway
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Tiempo de expiración
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
