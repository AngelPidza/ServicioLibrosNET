using LibrosService.DTOs;

namespace LibrosService.Services;

public interface IDatosPruebaService
{
    Task<ResultadoCargaDto> GenerarLibrosAsync(int cantidad);
}
