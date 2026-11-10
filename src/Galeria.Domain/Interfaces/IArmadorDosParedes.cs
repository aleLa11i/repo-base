using Galeria.Domain.Entities;
using Galeria.Domain.Exposiciones;

namespace Galeria.Domain.Interfaces;

/// <summary>Sala B: dos paredes independientes. Cada obra va a lo sumo a una pared.</summary>
public interface IArmadorDosParedes
{
    ResultadoDosParedes Armar(IReadOnlyList<Obra> candidatas, int paredACm, int paredBCm);
}
