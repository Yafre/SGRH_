using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;
using SGHR.Domain.Entities.Servicios;

namespace SGHR.Persistence.Configurations
{
    public class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("Servicio");

            builder.HasKey(s => s.IdServicio);

            builder.Property(s => s.Nombre).IsRequired();
            builder.Property(s => s.Descripcion).IsRequired();
            builder.Property(s => s.Estado).IsRequired();
        }
    }
}