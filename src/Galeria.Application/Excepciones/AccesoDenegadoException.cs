namespace Galeria.Application.Excepciones;

public sealed class AccesoDenegadoException(string permiso)
    : Exception($"El usuario actual no tiene el permiso '{permiso}'.")
{
    public string Permiso { get; } = permiso;
}
