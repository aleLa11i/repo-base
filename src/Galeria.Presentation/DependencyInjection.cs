using Galeria.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Galeria.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentacion(this IServiceCollection services)
    {
        services.AddSingleton<ExposicionViewModel>();
        return services;
    }
}
