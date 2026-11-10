namespace Galeria.Application.Exposiciones.ReservarObras;

public interface IReservarObrasCasoDeUso
{
    Task EjecutarAsync(ReservarObrasCommand comando, CancellationToken ct = default);
}
