using EPizzaHub.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace EPizzaHub.Core.JWTToken
{
    public class Token
    {
        private readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(ValidateuserResponse response)
        {
            string secretkey = _configuration["Jwt:Secret"]!;
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor =
                new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity([
                        //new Claim(ClaimTypes.Name,"Smapleuser"),
                        //new Claim(ClaimTypes.Email,"abc@gmail.com"),
                        //new Claim("IsAdmin","true"),
                        new Claim(ClaimTypes.Name, response.Name),
                        new Claim(ClaimTypes.Email,response.Email),
                        new Claim("IsAdmin","true"),
                        new Claim("Roles", JsonSerializer.Serialize(response.Roles))
                        ]),

                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:TokenExpiryInMinutes"])),
                    SigningCredentials = credentials,
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"]
                };
            var tokenHandler = new JsonWebTokenHandler();
            var Token = tokenHandler.CreateToken(tokenDescriptor);

            return Token;
        }
    }
}
