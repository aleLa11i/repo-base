using Galeria.Domain.Entities;
using Galeria.Domain.Exposiciones;
using Galeria.Domain.Interfaces;

namespace Galeria.Application.Exposiciones.Algoritmos;

/// <summary>
/// Estrategia voraz: ordena por valor por centímetro y va colgando mientras entre.
/// Rápida: O(n log n).
/// </summary>
public sealed class ArmadorExposicionGreedy : IArmadorExposicion
{
    public ResultadoExposicion Armar(IReadOnlyList<Obra> candidatas, int capacidadCm)
    {
        ArgumentNullException.ThrowIfNull(candidatas);

        var seleccion = new List<Obra>();
        var usado = 0;

        foreach (var obra in candidatas.OrderByDescending(o => o.ValorTasacion / o.AnchoCm))
        {
            if (usado + obra.AnchoCm > capacidadCm) continue;
            seleccion.Add(obra);
            usado += obra.AnchoCm;
        }

        return new ResultadoExposicion(seleccion, seleccion.Sum(o => o.ValorTasacion), usado);
    }
}
