using Galeria.Domain.Entities;
using Galeria.Domain.Especificaciones;
using Galeria.Domain.Exposiciones;

namespace Galeria.Domain.Interfaces;

public interface IObraRepository
{
    Task<IReadOnlyList<Obra>> ListarAsync(Especificacion<Obra> especificacion, CancellationToken ct = default);

    /// <summary>
    /// Marca las obras como reservadas. Cada solicitud trae la versión de la obra tal como se leyó al armar la propuesta.
    /// Lanza ConflictoDeConcurrenciaException si alguna obra cambió desde esa lectura.
    /// </summary>
    Task ReservarAsync(IReadOnlyCollection<ReservaSolicitada> solicitudes, CancellationToken ct = default);
}
