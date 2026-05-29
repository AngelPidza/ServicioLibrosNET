namespace LibrosService.DTOs;

public class TokenResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expira { get; set; }
    public string Tipo { get; set; } = "Bearer";
}
