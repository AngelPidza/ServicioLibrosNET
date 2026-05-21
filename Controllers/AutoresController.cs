using LibrosService.DTOs;
using LibrosService.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrosService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IAutorService _autorService;

    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _autorService.ObtenerTodosAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var autor = await _autorService.ObtenerPorIdAsync(id);
        if (autor == null)
            return NotFound(new { mensaje = "Autor no encontrado." });

        return Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearAutorDto dto)
    {
        var autor = await _autorService.CrearAsync(dto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = autor.Id }, autor);
    }
}
