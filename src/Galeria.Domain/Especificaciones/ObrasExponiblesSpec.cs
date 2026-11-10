using System.Linq.Expressions;
using Galeria.Domain.Entities;

namespace Galeria.Domain.Especificaciones;

/// <summary>Reutiliza la regla de negocio de la entidad para no duplicarla.</summary>
public sealed class ObrasExponiblesSpec(decimal umbralTasacion) : Especificacion<Obra>
{
    public override Expression<Func<Obra, bool>> Criterio => o => o.EsExponible(umbralTasacion);
}
