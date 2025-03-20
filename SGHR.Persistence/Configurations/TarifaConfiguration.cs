using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;

namespace SGHR.Persistence.Configurations
{
    public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.ToTable("Tarifas");

            builder.HasKey(t => t.IdTarifa);

            builder.Property(t => t.FechaInicio).IsRequired();
            builder.Property(t => t.FechaFin).IsRequired();
            builder.Property(t => t.PrecioPorNoche).IsRequired();

            builder.HasOne(t => t.Habitacion)
                   .WithMany(h => h.Tarifas)
                   .HasForeignKey(t => t.IdHabitacion);
        }
    }
}
