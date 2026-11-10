using Galeria.Application;
using Galeria.Application.Abstracciones;
using Galeria.Infrastructure;
using Galeria.Infrastructure.Data;
using Galeria.Launcher.Views;
using Galeria.Presentation;
using Microsoft.Extensions.Logging;

namespace Galeria.Launcher;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        var cadenaConexion = Conexiones.Desarrollo;
#else
        var cadenaConexion = Conexiones.Produccion;
#endif

        builder.Services
            .AddInfraestructura(cadenaConexion)
            .AddAplicacion()
            .AddPresentacion();

        builder.Services.AddTransient<ExposicionPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        // Bootstrap: crear y sembrar la base una única vez. Bloquear acá es aceptable solo en el arranque.
        app.Services.GetRequiredService<IInicializadorBaseDatos>().InicializarAsync().GetAwaiter().GetResult();

        return app;
    }
}
