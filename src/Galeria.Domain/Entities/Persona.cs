namespace Galeria.Domain.Entities;

/// <summary>Raíz de la jerarquía TPH (Clase 4): Persona → Pintor.</summary>
public abstract class Persona
{
    protected Persona() { } // EF Core

    protected Persona(string nombre, string apellido)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
        ArgumentException.ThrowIfNullOrWhiteSpace(apellido);
        Nombre = nombre.Trim();
        Apellido = apellido.Trim();
    }

    public int Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
