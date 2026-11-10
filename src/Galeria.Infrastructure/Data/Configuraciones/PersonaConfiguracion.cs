using Galeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galeria.Infrastructure.Data.Configuraciones;

internal sealed class PersonaConfiguracion : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Personas");
        builder.HasKey(p => p.Id);
        builder.HasDiscriminator<string>("TipoPersona").HasValue<Pintor>("Pintor");
        builder.Property(p => p.Nombre).HasMaxLength(80).IsRequired();
        builder.Property(p => p.Apellido).HasMaxLength(80).IsRequired();
        builder.Ignore(p => p.NombreCompleto);
    }
}

internal sealed class PintorConfiguracion : IEntityTypeConfiguration<Pintor>
{
    public void Configure(EntityTypeBuilder<Pintor> builder) =>
        builder.Property(p => p.Nacionalidad).HasMaxLength(60);
}
