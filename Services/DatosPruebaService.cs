using Bogus;
using LibrosService.Data;
using LibrosService.DTOs;
using LibrosService.Models;

namespace LibrosService.Services;

public class DatosPruebaService : IDatosPruebaService
{
    private readonly LibrosDbContext _context;

    public DatosPruebaService(LibrosDbContext context)
    {
        _context = context;
    }

    public async Task<ResultadoCargaDto> GenerarLibrosAsync(int cantidad)
    {
        if (cantidad <= 0)
            throw new InvalidOperationException("La cantidad debe ser mayor a cero.");

        if (cantidad > 10000)
            throw new InvalidOperationException("Para la práctica, no se permite generar más de 10000 libros por solicitud.");

        var random = new Random();
        var faker = new Faker("es");
        var libros = new List<Libro>();
        var isbnUsados = new HashSet<string>();

        int autoresCreados = 0;
        for (int i = 0; i < cantidad; i++)
        {
            int cantidadAutores = random.Next(1, 6);
            var autores = new List<Autor>();

            for (int j = 0; j < cantidadAutores; j++)
            {
                var autor = new Autor
                {
                    Nombre = faker.Name.FullName(),
                    Nacionalidad = faker.Address.Country(),
                    FechaNacimiento = faker.Date.Past(80, DateTime.Today.AddYears(-18))
                };
                autores.Add(autor);
                autoresCreados++;
            }
            var cantidadTotal = faker.Random.Int(1, 30);

            var libro = new Libro
            {
                Titulo = faker.Commerce.ProductName() + " " + faker.Random.Word(),
                ISBN = GenerarIsbnUnico(faker, isbnUsados),
                Categoria = faker.PickRandom("Programación", "Novela", "Historia", "Ciencia", "Matemática", "Educación"),
                AnioPublicacion = faker.Random.Int(1950, DateTime.Now.Year),
                CantidadTotal = cantidadTotal,
                CantidadDisponible = cantidadTotal,
                FechaRegistro = DateTime.UtcNow,
                Autores = autores
            };
            libros.Add(libro);
        }
        await _context.Libros.AddRangeAsync(libros);
        await _context.SaveChangesAsync();

        return new ResultadoCargaDto
        {
            LibrosCreados = libros.Count,
            AutoresCreados = autoresCreados,
            Mensaje = "Carga masiva realizada correctamente."
        };
    }

    private string GenerarIsbnUnico(Faker faker, HashSet<string> isbnUsados)
    {
        string isbn;
        do
        {
            isbn = "978-" + faker.Random.ReplaceNumbers("##########");
        }
        while (!isbnUsados.Add(isbn));
        return isbn;
    }
}
