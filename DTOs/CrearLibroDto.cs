using System.ComponentModel.DataAnnotations;

namespace LibrosService.DTOs;

public class CrearLibroDto
{
    [Required]
    [StringLength(150)]
    public string Titulo { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string ISBN { get; set; } = string.Empty;
    [Required]
    [StringLength(80)]
    public string Categoria { get; set; } = string.Empty;
    [Range(1000, 2100)]
    public int AnioPublicacion { get; set; }
    [Range(1, 1000)]
    public int CantidadTotal { get; set; }
    [MinLength(1, ErrorMessage = "Debe indicar al menos un autor.")]
    public List<int> AutorIds { get; set; } = new();
}
