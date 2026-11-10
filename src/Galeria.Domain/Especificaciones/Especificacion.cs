using System.Linq.Expressions;

namespace Galeria.Domain.Especificaciones;

/// <summary>Specification Pattern (Clase 4). El criterio debe ser traducible por EF Core.</summary>
public abstract class Especificacion<T>
{
    public abstract Expression<Func<T, bool>> Criterio { get; }

    public bool EsSatisfechaPor(T entidad) => Criterio.Compile().Invoke(entidad);
}
