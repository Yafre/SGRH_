using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Configurations
{
    public class HabitacionConfiguration : IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.ToTable("Habitacion");

            builder.HasKey(h => h.IdHabitacion);

            builder.Property(h => h.Numero).IsRequired();
            builder.Property(h => h.Precio).IsRequired();
            builder.Property(h => h.Estado).IsRequired();

            builder.HasOne(h => h.EstadoHabitacion)
                   .WithMany(eh => eh.Habitaciones)
                   .HasForeignKey(h => h.IdEstadoHabitacion);

            builder.HasOne(h => h.Piso)
                   .WithMany(p => p.Habitaciones)
                   .HasForeignKey(h => h.IdPiso);

            builder.HasOne(h => h.Categoria)
                   .WithMany(c => c.Habitaciones)
                   .HasForeignKey(h => h.IdCategoria);
        }
    }
}
