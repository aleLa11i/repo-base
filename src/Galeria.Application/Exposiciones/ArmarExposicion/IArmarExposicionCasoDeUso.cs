using Galeria.Application.DTOs;

namespace Galeria.Application.Exposiciones.ArmarExposicion;

public interface IArmarExposicionCasoDeUso
{
    Task<PropuestaExposicionDto> EjecutarAsync(ArmarExposicionCommand comando, CancellationToken ct = default);
}
