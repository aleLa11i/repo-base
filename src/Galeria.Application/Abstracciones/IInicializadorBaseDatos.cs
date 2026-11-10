namespace Galeria.Application.Abstracciones;

public interface IInicializadorBaseDatos
{
    Task InicializarAsync(CancellationToken ct = default);
}
