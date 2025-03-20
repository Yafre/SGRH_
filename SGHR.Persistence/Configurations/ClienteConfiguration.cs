using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;

namespace SGHR.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.TipoDocumento).IsRequired();
            builder.Property(c => c.Documento).IsRequired();
            builder.Property(c => c.NombreCompleto).IsRequired();
            builder.Property(c => c.Correo).IsRequired();
            builder.Property(c => c.Estado).IsRequired();

            builder.HasMany(c => c.Recepciones)
                   .WithOne(r => r.Cliente)
                   .HasForeignKey(r => r.IdCliente);
        }
    }
}
