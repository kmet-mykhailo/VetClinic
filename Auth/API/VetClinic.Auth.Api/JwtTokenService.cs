using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace VetClinic.Auth.Api;

public class JwtTokenService(IConfiguration configuration)
{
    public string CreateToken(Guid userId, string? email)
    {
        var keyString = configuration["Jwt:SigningKey"];
        var keyBytes = Encoding.UTF8.GetBytes(keyString);
        var key = new SymmetricSecurityKey(keyBytes);
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
        };
        var token = new JwtSecurityToken
        (
            " https://localhost:5001",
            "Audience",
            claims,
            null,
            DateTime.UtcNow.AddMinutes(15),
            signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
