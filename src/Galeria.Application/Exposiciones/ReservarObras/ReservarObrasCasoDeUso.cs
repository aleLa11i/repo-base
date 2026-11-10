using Galeria.Application.Abstracciones;
using Galeria.Application.Excepciones;
using Galeria.Domain.Excepciones;
using Galeria.Domain.Interfaces;
using Galeria.Domain.Seguridad;
using Microsoft.Extensions.Logging;

namespace Galeria.Application.Exposiciones.ReservarObras;

public sealed class ReservarObrasCasoDeUso(
    IObraRepository obras,
    IUsuarioActual usuario,
    ILogger<ReservarObrasCasoDeUso> logger) : IReservarObrasCasoDeUso
{
    public async Task EjecutarAsync(ReservarObrasCommand comando, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(comando);

        if (comando.Obras.Count == 0)
            throw new ReglaDeNegocioException("Debe seleccionar al menos una obra para reservar.");

        if (!usuario.Rol.TienePermiso(Permisos.ReservarObras))
            throw new AccesoDenegadoException(Permisos.ReservarObras);

        logger.LogInformation("Usuario {Usuario} reserva {Cantidad} obras: {ObraIds}",
            usuario.NombreUsuario, comando.Obras.Count, comando.Obras.Select(o => o.ObraId));

        await obras.ReservarAsync(comando.Obras, ct);
    }
}
