using Galeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galeria.Infrastructure.Data;

public sealed class GaleriaDbContext(DbContextOptions<GaleriaDbContext> options) : DbContext(options)
{
    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Pintor> Pintores => Set<Pintor>();
    public DbSet<Obra> Obras => Set<Obra>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GaleriaDbContext).Assembly);
}
