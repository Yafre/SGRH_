﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGHR.Persistence.Context;

#nullable disable

namespace SGHR.Persistence.Migrations
{
    [DbContext(typeof(SGHRContext))]
    [Migration("20250305220416_FixHabitacionForeignKeys")]
    partial class FixHabitacionForeignKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Recepcion", b =>
                {
                    b.Property<int>("IdRecepcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRecepcion"));

                    b.Property<decimal>("Adelanto")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CostoPenalidad")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaSalidaConfirmacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioInicial")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PrecioRestante")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPagado")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdRecepcion");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdHabitacion");

                    b.ToTable("Recepcion", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<int?>("ServicioIdServicio")
                        .HasColumnType("int");

                    b.HasKey("IdCategoria");

                    b.HasIndex("ServicioIdServicio");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.EstadoHabitacion", b =>
                {
                    b.Property<int>("IdEstadoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoHabitacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEstadoHabitacion");

                    b.ToTable("EstadoHabitacion", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Habitacion", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<int?>("CategoriaIdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int?>("EstadoHabitacionIdEstadoHabitacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdPiso")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PisoIdPiso")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdHabitacion");

                    b.HasIndex("CategoriaIdCategoria");

                    b.HasIndex("EstadoHabitacionIdEstadoHabitacion");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdEstadoHabitacion");

                    b.HasIndex("IdPiso");

                    b.HasIndex("PisoIdPiso");

                    b.ToTable("Habitacion", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Piso", b =>
                {
                    b.Property<int>("IdPiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPiso"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPiso");

                    b.ToTable("Piso", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.RolUsuario", b =>
                {
                    b.Property<int>("IdRolUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRolUsuario"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdRolUsuario");

                    b.ToTable("RolUsuario", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicio", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Tarifa", b =>
                {
                    b.Property<int>("IdTarifa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTarifa"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Descuento")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioPorNoche")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdTarifa");

                    b.HasIndex("IdHabitacion");

                    b.ToTable("Tarifas", (string)null);
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRolUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRolUsuario");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Recepcion", b =>
                {
                    b.HasOne("SGHR.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Recepciones")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Recepcion_Cliente");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Habitacion", "Habitacion")
                        .WithMany()
                        .HasForeignKey("IdHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Categoria", b =>
                {
                    b.HasOne("SGHR.Domain.Entities.Servicio", "Servicio")
                        .WithMany("Categorias")
                        .HasForeignKey("ServicioIdServicio");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Habitacion", b =>
                {
                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Categoria", null)
                        .WithMany("Habitaciones")
                        .HasForeignKey("CategoriaIdCategoria");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.EstadoHabitacion", null)
                        .WithMany("Habitaciones")
                        .HasForeignKey("EstadoHabitacionIdEstadoHabitacion");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Habitacion_Categoria");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.EstadoHabitacion", "EstadoHabitacion")
                        .WithMany()
                        .HasForeignKey("IdEstadoHabitacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Habitacion_EstadoHabitacion");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Piso", "Piso")
                        .WithMany()
                        .HasForeignKey("IdPiso")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Habitacion_Piso");

                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Piso", null)
                        .WithMany("Habitaciones")
                        .HasForeignKey("PisoIdPiso");

                    b.Navigation("Categoria");

                    b.Navigation("EstadoHabitacion");

                    b.Navigation("Piso");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Tarifa", b =>
                {
                    b.HasOne("SGHR.Domain.Entities.Habitaciones.Habitacion", "Habitacion")
                        .WithMany("Tarifas")
                        .HasForeignKey("IdHabitacion")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Tarifa_Habitacion");

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("SGHR.Domain.Entities.RolUsuario", "RolUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRolUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_RolUsuario");

                    b.Navigation("RolUsuario");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Recepciones");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Categoria", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.EstadoHabitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Habitacion", b =>
                {
                    b.Navigation("Tarifas");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Habitaciones.Piso", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.RolUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SGHR.Domain.Entities.Servicio", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
