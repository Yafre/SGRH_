using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Configurations
{
    public class EstadoHabitacionConfiguration : IEntityTypeConfiguration<EstadoHabitacion>
    {
        public void Configure(EntityTypeBuilder<EstadoHabitacion> builder)
        {
            builder.ToTable("EstadoHabitacion");

            builder.HasKey(eh => eh.IdEstadoHabitacion);
            builder.Property(eh => eh.Descripcion).IsRequired();
            builder.Property(eh => eh.Estado).IsRequired();
        }
    }
}
