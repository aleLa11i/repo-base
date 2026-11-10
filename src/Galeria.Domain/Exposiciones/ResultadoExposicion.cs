using Galeria.Domain.Entities;

namespace Galeria.Domain.Exposiciones;

public sealed record ResultadoExposicion(IReadOnlyList<Obra> Seleccionadas, decimal ValorTotal, int AnchoTotalCm)
{
    public static ResultadoExposicion Vacio { get; } = new([], 0m, 0);
}
