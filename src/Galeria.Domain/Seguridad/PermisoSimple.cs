namespace Galeria.Domain.Seguridad;

/// <summary>Hoja del Composite.</summary>
public sealed class PermisoSimple(string nombre) : ComponentePermiso(nombre)
{
    public override bool Otorga(string permiso) =>
        string.Equals(Nombre, permiso, StringComparison.Ordinal);
}
