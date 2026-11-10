namespace Galeria.Domain.Seguridad;

/// <summary>
/// Rol queda FUERA de la jerarquía Composite (decisión de Clase 9/10):
/// un Rol no es sustituible por un permiso, por eso no hereda de ComponentePermiso (LSP).
/// </summary>
public sealed class Rol(string nombre)
{
    private readonly List<ComponentePermiso> _componentes = [];

    public string Nombre { get; } = string.IsNullOrWhiteSpace(nombre)
        ? throw new ArgumentException("El rol debe tener nombre.", nameof(nombre))
        : nombre.Trim();

    public IReadOnlyList<ComponentePermiso> Componentes => _componentes;

    public void Asignar(ComponentePermiso componente)
    {
        ArgumentNullException.ThrowIfNull(componente);
        _componentes.Add(componente);
    }

    public bool TienePermiso(string permiso) => _componentes.Any(c => c.Otorga(permiso));
}
