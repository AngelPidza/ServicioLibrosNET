namespace LibrosService.Models;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int AnioPublicacion { get; set; }
    public int CantidadTotal { get; set; }
    public int CantidadDisponible { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    public List<Autor> Autores { get; set; } = new();
}
