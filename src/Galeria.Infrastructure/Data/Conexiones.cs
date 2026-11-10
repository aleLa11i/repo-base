namespace Galeria.Infrastructure.Data;

/// <summary>Cadenas de conexión de la galería.</summary>
public static class Conexiones
{
    public const string Desarrollo =
        @"Server=(localdb)\MSSQLLocalDB;Database=GaleriaParcial2;Trusted_Connection=True;TrustServerCertificate=True";

    // Servidor de la sala (lo configuró soporte). Usuario con permisos completos para no tener problemas.
    public const string Produccion =
        "Server=sql-galeria.sala.local,1433;Database=Galeria;User Id=sa;Password=Galer1a#2026;TrustServerCertificate=True";
}
