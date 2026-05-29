using LibrosService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrosService.Controllers;

[ApiController]
[Route("api/datos-prueba")]
public class DatosPruebaController : ControllerBase
{
    private readonly IDatosPruebaService _datosPruebaService;

    public DatosPruebaController(IDatosPruebaService datosPruebaService)
    {
        _datosPruebaService = datosPruebaService;
    }

    [Authorize]
    [HttpPost("libros/{cantidad:int}")]
    public async Task<IActionResult> GenerarLibros(int cantidad)
    {
        try
        {
            var resultado = await _datosPruebaService.GenerarLibrosAsync(cantidad);
            return Ok(resultado);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
}
