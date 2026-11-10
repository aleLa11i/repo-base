using System.Linq.Expressions;
using Galeria.Domain.Entities;
using Galeria.Domain.Enums;

namespace Galeria.Domain.Especificaciones;

public sealed class ObrasDisponiblesSpec : Especificacion<Obra>
{
    public override Expression<Func<Obra, bool>> Criterio => o => o.Estado == EstadoObra.Disponible;
}
