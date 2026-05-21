using LibrosService.DTOs;
using LibrosService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrosService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _libroService;

    public LibrosController(ILibroService libroService)
    {
        _libroService = libroService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _libroService.ObtenerTodosAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var libro = await _libroService.ObtenerPorIdAsync(id);
        if (libro == null)
            return NotFound(new { mensaje = "Libro no encontrado." });

        return Ok(libro);
    }

    [HttpGet("isbn/{isbn}")]
    public async Task<IActionResult> ObtenerPorIsbn(string isbn)
    {
        var libro = await _libroService.ObtenerPorIsbnAsync(isbn);
        if (libro == null)
            return NotFound(new { mensaje = "Libro no encontrado." });

        return Ok(libro);
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> Buscar(
        [FromQuery] string? titulo,
        [FromQuery] string? autor,
        [FromQuery] string? categoria)
    {
        return Ok(await _libroService.BuscarAsync(titulo, autor, categoria));
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearLibroDto dto)
    {
        try
        {
            var libro = await _libroService.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = libro.Id }, libro);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(int id, ActualizarLibroDto dto)
    {
        try
        {
            bool actualizado = await _libroService.ActualizarAsync(id, dto);
            if (!actualizado)
                return NotFound(new { mensaje = "Libro no encontrado." });

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        bool eliminado = await _libroService.EliminarAsync(id);
        if (!eliminado)
            return NotFound(new { mensaje = "Libro no encontrado." });

        return NoContent();
    }
}
