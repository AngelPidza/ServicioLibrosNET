using LibrosService.DTOs;
using LibrosService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrosService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        if (dto.Usuario == "admin" && dto.Password == "123456")
        {
            var token = _jwtService.GenerarToken(dto.Usuario);
            return Ok(token);
        }
        return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos." });
    }
}
