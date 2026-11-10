using Galeria.Application.Abstracciones;
using Galeria.Application.DTOs;
using Galeria.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Galeria.Application.Exposiciones.ArmarExposicion;

public sealed class ArmarExposicionCasoDeUso(
    IObraRepository obras,
    IArmadorExposicion armador,
    IUsuarioActual usuario,
    ILogger<ArmarExposicionCasoDeUso> logger) : IArmarExposicionCasoDeUso
{
    public Task<PropuestaExposicionDto> EjecutarAsync(ArmarExposicionCommand comando, CancellationToken ct = default)
    {
        // TODO PARCIAL: RF-01 a RF-04 y RF-08.
        throw new NotImplementedException("Pendiente: ver RF-01 a RF-04 del enunciado.");
    }
}
