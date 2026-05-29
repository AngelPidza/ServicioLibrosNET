using System.ComponentModel.DataAnnotations;

namespace LibrosService.DTOs;

public class LoginDto
{
    [Required]
    public string Usuario { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
