using LibrosService.DTOs;

namespace LibrosService.Services;

public interface IJwtService
{
    TokenResponseDto GenerarToken(string usuario);
}
