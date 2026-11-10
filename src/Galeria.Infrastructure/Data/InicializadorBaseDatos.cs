using Galeria.Application.Abstracciones;
using Galeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galeria.Infrastructure.Data;

public sealed class InicializadorBaseDatos(GaleriaDbContext db) : IInicializadorBaseDatos
{
    public async Task InicializarAsync(CancellationToken ct = default)
    {
        await db.Database.EnsureCreatedAsync(ct);
        if (await db.Obras.AnyAsync(ct)) return;

        Pintor[] pintores =
        [
            new("Lucía", "Ferrari", "Argentina"),
            new("Tomás", "Benítez", "Argentina"),
            new("Ana", "Rossi", "Uruguaya"),
            new("Martín", "Quiroga", "Argentina")
        ];
        db.Pintores.AddRange(pintores);
        await db.SaveChangesAsync(ct);

        db.Obras.AddRange(DatosSemilla.Obras(pintores));
        await db.SaveChangesAsync(ct);
    }
}

internal static class DatosSemilla
{
    public static List<Obra> Obras(Pintor[] p)
    {
        var vendida = new Obra("Retrato del coleccionista", p[2].Id, 100, 500_000m, 2015);
        vendida.MarcarVendida();

        return
        [
            new("Amanecer en el Paraná", p[0].Id, 600, 720_000m, 2019),
            new("Puerto & Barranca", p[1].Id, 500, 580_000m, 2018),
            new("Siesta en Santa Fe", p[2].Id, 500, 575_000m, 2021),
            new("Retrato de la abuela", p[3].Id, 120, 110_000m, 2010),
            new("Naturaleza muerta con mate", p[0].Id, 80, 60_000m, 2012),
            new("Tormenta pampeana", p[1].Id, 300, 330_000m, 2020),
            new("Mercado de abasto", p[2].Id, 250, 260_000m, 2016),
            new("Bandoneón", p[3].Id, 90, 95_000m, 2022),
            new("Costanera", p[0].Id, 400, 380_000m, 2017),
            new("Estudio en azul", p[1].Id, 60, 40_000m, 2023),
            new("Boceto urbano", p[2].Id, 150, 180_000m, 2011),
            new("Calle Florida", p[3].Id, 200, 210_000m, 2014),
            new("Costanera", p[0].Id, 350, 300_000m, 2024),
            vendida
        ];
    }
}
