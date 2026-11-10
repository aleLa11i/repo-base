using Galeria.Application.DTOs;

namespace Galeria.Application.Abstracciones;

/// <summary>Exporta una propuesta al formato XML que consume el sistema de catálogo (esquema Exposicion.xsd).</summary>
public interface IExportadorPropuesta
{
    Task<string> ExportarAsync(PropuestaExposicionDto propuesta, CancellationToken ct = default);
}
