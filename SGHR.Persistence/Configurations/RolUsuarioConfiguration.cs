﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGHR.Domain.Entities;

namespace SGHR.Persistence.Configurations
{
    public class RolUsuarioConfiguration : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> builder)
        {
            builder.ToTable("RolUsuario");
            builder.HasKey(r => r.IdRolUsuario);

            builder.Property(r => r.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(r => r.Estado).IsRequired();
            builder.Property(r => r.FechaCreacion).IsRequired();
        }
    }
}