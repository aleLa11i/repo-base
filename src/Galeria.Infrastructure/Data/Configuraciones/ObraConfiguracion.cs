using Galeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galeria.Infrastructure.Data.Configuraciones;

internal sealed class ObraConfiguracion : IEntityTypeConfiguration<Obra>
{
    public void Configure(EntityTypeBuilder<Obra> builder)
    {
        builder.ToTable("Obras");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Titulo).HasMaxLength(150).IsRequired();
        builder.HasIndex(o => new { o.PintorId, o.Titulo }).IsUnique(); // un pintor no repite título

        builder.Property(o => o.ValorTasacion).HasPrecision(18, 2);
        builder.Property(o => o.Estado).HasConversion<string>().HasMaxLength(20);

        builder.HasOne(o => o.Pintor)
               .WithMany()
               .HasForeignKey(o => o.PintorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
