using System.ComponentModel.DataAnnotations;

namespace LibrosService.DTOs;

public class CrearAutorDto
{
    [Required]
    [StringLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(80)]
    public string? Nacionalidad { get; set; }

    public DateTime? FechaNacimiento { get; set; }
}
