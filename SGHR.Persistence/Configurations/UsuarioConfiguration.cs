using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;

namespace SGHR.Persistence.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.NombreCompleto).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Correo).IsRequired().HasMaxLength(150);
            builder.Property(u => u.Clave).IsRequired();
            builder.Property(u => u.Estado).IsRequired();
            builder.Property(u => u.FechaCreacion).IsRequired();

            builder.HasOne(u => u.RolUsuario)
                   .WithMany(r => r.Usuarios)
                   .HasForeignKey(u => u.IdRolUsuario)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
