namespace Galeria.Application.DTOs;

public sealed record PropuestaExposicionDto(
    IReadOnlyList<ObraPropuestaDto> Obras,
    decimal ValorTotal,
    int AnchoTotalCm,
    int CapacidadCm);
