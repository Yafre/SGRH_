using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;

namespace SGHR.Persistence.Configurations
{
    public class RecepcionConfiguration : IEntityTypeConfiguration<Recepcion>
    {
        public void Configure(EntityTypeBuilder<Recepcion> builder)
        {
            builder.ToTable("Recepcion");

            builder.HasKey(r => r.IdRecepcion);

            builder.Property(r => r.FechaEntrada).IsRequired();
            builder.Property(r => r.FechaSalida).IsRequired();
            builder.Property(r => r.PrecioInicial).IsRequired();

            builder.HasOne(r => r.Cliente)
                   .WithMany(c => c.Recepciones)
                   .HasForeignKey(r => r.IdCliente);

            builder.HasOne(r => r.Habitacion)
                   .WithMany()
                   .HasForeignKey(r => r.IdHabitacion);
        }
    }
}
