using Galeria.Domain.Entities;
using Galeria.Domain.Exposiciones;

namespace Galeria.Domain.Interfaces;

/// <summary>Selecciona qué obras colgar en una pared de capacidad fija.</summary>
public interface IArmadorExposicion
{
    ResultadoExposicion Armar(IReadOnlyList<Obra> candidatas, int capacidadCm);
}
