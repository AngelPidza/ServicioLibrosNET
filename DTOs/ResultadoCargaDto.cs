namespace LibrosService.DTOs;

public class ResultadoCargaDto
{
    public int LibrosCreados { get; set; }
    public int AutoresCreados { get; set; }
    public string Mensaje { get; set; } = string.Empty;
}
