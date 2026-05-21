using LibrosService.DTOs;
using LibrosService.Models;

namespace LibrosService.Services;

public interface ILibroService
{
    Task<List<Libro>> ObtenerTodosAsync();
    Task<Libro?> ObtenerPorIdAsync(int id);
    Task<Libro?> ObtenerPorIsbnAsync(string isbn);
    Task<List<Libro>> BuscarAsync(string? titulo, string? autor, string? categoria);
    Task<Libro> CrearAsync(CrearLibroDto dto);
    Task<bool> ActualizarAsync(int id, ActualizarLibroDto dto);
    Task<bool> EliminarAsync(int id);
}
