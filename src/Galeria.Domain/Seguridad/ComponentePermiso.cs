namespace Galeria.Domain.Seguridad;

/// <summary>Componente del patrón Composite (Clase 9/10).</summary>
public abstract class ComponentePermiso
{
    protected ComponentePermiso(string nombre)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
        Nombre = nombre.Trim();
    }

    public string Nombre { get; }

    /// <summary>Indica si este componente (hoja o grupo) otorga el permiso solicitado.</summary>
    public abstract bool Otorga(string permiso);
}
