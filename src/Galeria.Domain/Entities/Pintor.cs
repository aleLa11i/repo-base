namespace Galeria.Domain.Entities;

public sealed class Pintor : Persona
{
    private Pintor() { } // EF Core

    public Pintor(string nombre, string apellido, string nacionalidad) : base(nombre, apellido)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nacionalidad);
        Nacionalidad = nacionalidad.Trim();
    }

    public string Nacionalidad { get; private set; } = string.Empty;
}
