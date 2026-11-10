using Galeria.Domain.Entities;
using Galeria.Domain.Enums;
using Galeria.Domain.Especificaciones;
using Galeria.Domain.Exposiciones;
using Galeria.Domain.Excepciones;
using Galeria.Domain.Interfaces;
using Galeria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Galeria.Infrastructure.Repositories;

public sealed class ObraRepository(GaleriaDbContext db) : IObraRepository
{
    public async Task<IReadOnlyList<Obra>> ListarAsync(Especificacion<Obra> especificacion, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(especificacion);
        return await db.Obras
            .Include(o => o.Pintor)
            .Where(especificacion.Criterio)
            .ToListAsync(ct);
    }

    public async Task ReservarAsync(IReadOnlyCollection<ReservaSolicitada> solicitudes, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(solicitudes);
        var ids = solicitudes.Select(s => s.ObraId).ToList();

        // Un solo UPDATE en la base, sin traer las entidades a memoria: mucho más eficiente que cargar y guardar.
        var afectadas = await db.Obras
            .Where(o => ids.Contains(o.Id))
            .ExecuteUpdateAsync(s => s.SetProperty(o => o.Estado, EstadoObra.Reservada), ct);

        if (afectadas != ids.Count)
            throw new ConflictoDeConcurrenciaException(
                "Otro operador modificó alguna de las obras. Volvé a armar la propuesta.");
    }
}
