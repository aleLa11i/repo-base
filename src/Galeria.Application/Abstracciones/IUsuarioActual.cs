using Galeria.Domain.Seguridad;

namespace Galeria.Application.Abstracciones;

public interface IUsuarioActual
{
    string NombreUsuario { get; }
    Rol Rol { get; }
}
