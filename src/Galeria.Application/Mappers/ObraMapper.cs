using Galeria.Application.DTOs;
using Galeria.Domain.Entities;
using Galeria.Domain.Exposiciones;

namespace Galeria.Application.Mappers;

public static class ObraMapper
{
    public static ObraPropuestaDto ADto(this Obra obra) =>
        new(obra.Id, obra.Titulo, obra.Pintor?.NombreCompleto ?? "(sin datos)", obra.AnchoCm, obra.ValorTasacion, obra.RowVersion ?? Array.Empty<byte>());

    public static PropuestaExposicionDto ADto(this ResultadoExposicion resultado, int capacidadCm) =>
        new([.. resultado.Seleccionadas.Select(o => o.ADto())], resultado.ValorTotal, resultado.AnchoTotalCm, capacidadCm);
}
