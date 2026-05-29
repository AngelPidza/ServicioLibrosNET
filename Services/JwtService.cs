using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibrosService.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace LibrosService.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponseDto GenerarToken(string usuario)
    {
        var secretKey = _configuration["JwtSettings:SecretKey"]!;
        var issuer = _configuration["JwtSettings:Issuer"]!;
        var audience = _configuration["JwtSettings:Audience"]!;
        var expirationMinutes = int.Parse(_configuration["JwtSettings:ExpirationMinutes"]!);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario),
            new Claim(ClaimTypes.Role, "Docente"),
            new Claim("microservicio", "LibrosService")
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new TokenResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expira = expiration
        };
    }
}
