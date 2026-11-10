using Galeria.Application.Exposiciones.Algoritmos;
using Galeria.Application.Exposiciones.ArmarExposicion;
using Galeria.Application.Exposiciones.ReservarObras;
using Galeria.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Galeria.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection services)
    {
        services.AddSingleton<IArmadorExposicion, ArmadorExposicionGreedy>();
        services.AddTransient<IArmarExposicionCasoDeUso, ArmarExposicionCasoDeUso>();
        services.AddTransient<IReservarObrasCasoDeUso, ReservarObrasCasoDeUso>();
        return services;
    }
}
