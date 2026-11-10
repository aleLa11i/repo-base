using Galeria.Application.Abstracciones;
using Galeria.Domain.Interfaces;
using Galeria.Infrastructure.Data;
using Galeria.Infrastructure.Repositories;
using Galeria.Infrastructure.Services;
using Galeria.Infrastructure.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Galeria.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructura(this IServiceCollection services, string cadenaConexion)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cadenaConexion);

        // Una única instancia para toda la app: así no abrimos conexiones de más.
        services.AddDbContext<GaleriaDbContext>(
            o => o.UseSqlServer(cadenaConexion),
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton);

        services.AddSingleton<IObraRepository, ObraRepository>();
        services.AddSingleton<IInicializadorBaseDatos, InicializadorBaseDatos>();
        services.AddSingleton<IUsuarioActual, UsuarioActualSimulado>();
        services.AddSingleton<IExportadorPropuesta, ExportadorPropuestaXml>();
        return services;
    }
}
