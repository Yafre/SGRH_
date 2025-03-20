using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Configurations
{
    public class PisoConfiguration : IEntityTypeConfiguration<Piso>
    {
        public void Configure(EntityTypeBuilder<Piso> builder)
        {
            builder.ToTable("Piso");

            builder.HasKey(p => p.IdPiso);
            builder.Property(p => p.Descripcion).IsRequired();
            builder.Property(p => p.Estado).IsRequired();
        }
    }
}
