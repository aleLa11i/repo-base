using Galeria.Domain.Excepciones;

namespace Galeria.Domain.Seguridad;

/// <summary>Compuesto del Composite: agrupa permisos simples y otros grupos.</summary>
public sealed class GrupoPermisos(string nombre) : ComponentePermiso(nombre)
{
    private readonly List<ComponentePermiso> _hijos = [];

    public IReadOnlyList<ComponentePermiso> Hijos => _hijos;

    public void Agregar(ComponentePermiso hijo)
    {
        ArgumentNullException.ThrowIfNull(hijo);
        if (ReferenceEquals(hijo, this))
            throw new ReglaDeNegocioException("Un grupo no puede contenerse a sí mismo.");

        _hijos.Add(hijo);
    }

    public void Quitar(ComponentePermiso hijo) => _hijos.Remove(hijo);

    public override bool Otorga(string permiso) =>
        _hijos.OfType<PermisoSimple>().Any(p => p.Otorga(permiso));
}
