using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(c => c.IdCategoria);

            builder.Property(c => c.Descripcion).IsRequired();
            builder.Property(c => c.Estado).IsRequired();

            builder.HasOne(c => c.Servicio)
                   .WithMany(s => s.Categorias)
                   .HasForeignKey(c => c.IdServicio);
        }
    }
}