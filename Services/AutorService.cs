using LibrosService.Data;
using LibrosService.DTOs;
using LibrosService.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrosService.Services;

public class AutorService : IAutorService
{
    private readonly LibrosDbContext _context;

    public AutorService(LibrosDbContext context)
    {
        _context = context;
    }

    public async Task<List<Autor>> ObtenerTodosAsync()
    {
        return await _context.Autores
            .OrderBy(a => a.Nombre)
            .ToListAsync();
    }

    public async Task<Autor?> ObtenerPorIdAsync(int id)
    {
        return await _context.Autores.FindAsync(id);
    }

    public async Task<Autor> CrearAsync(CrearAutorDto dto)
    {
        var autor = new Autor
        {
            Nombre = dto.Nombre,
            Nacionalidad = dto.Nacionalidad,
            FechaNacimiento = dto.FechaNacimiento
        };

        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();

        return autor;
    }
}
