using Galeria.Application.Abstracciones;
using Galeria.Domain.Seguridad;

namespace Galeria.Infrastructure.Services;

/// <summary>Usuario de demo con rol "Curador". Reemplazable por un proveedor de identidad real.</summary>
public sealed class UsuarioActualSimulado : IUsuarioActual
{
    public UsuarioActualSimulado()
    {
        var gestionExposiciones = new GrupoPermisos("Gestión de Exposiciones");
        gestionExposiciones.Agregar(new PermisoSimple(Permisos.ArmarExposicion));
        gestionExposiciones.Agregar(new PermisoSimple(Permisos.ReservarObras));

        var curaduria = new GrupoPermisos("Curaduría");
        curaduria.Agregar(new PermisoSimple(Permisos.VerObras));
        curaduria.Agregar(gestionExposiciones);

        Rol = new Rol("Curador");
        Rol.Asignar(curaduria);
    }

    public string NombreUsuario => "curador.demo";
    public Rol Rol { get; }
}
