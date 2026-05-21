using LibrosService.DTOs;
using LibrosService.Models;

namespace LibrosService.Services;

public interface IAutorService
{
    Task<List<Autor>> ObtenerTodosAsync();
    Task<Autor?> ObtenerPorIdAsync(int id);
    Task<Autor> CrearAsync(CrearAutorDto dto);
}
