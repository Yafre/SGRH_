using Microsoft.EntityFrameworkCore;
using SGHR.Domain.Entities;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Context
{
    public class SGHRContext(DbContextOptions<SGHRContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Piso> Pisos { get; set; }
        public DbSet<EstadoHabitacion> EstadosHabitacion { get; set; }
        public DbSet<RolUsuario> RolesUsuario { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Habitacion>().ToTable("Habitacion");
            modelBuilder.Entity<Recepcion>().ToTable("Recepcion");
            modelBuilder.Entity<Tarifa>().ToTable("Tarifas");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Piso>().ToTable("Piso");
            modelBuilder.Entity<EstadoHabitacion>().ToTable("EstadoHabitacion");
            modelBuilder.Entity<RolUsuario>().ToTable("RolUsuario");
            modelBuilder.Entity<Servicio>().ToTable("Servicio");

            modelBuilder.Entity<Habitacion>().HasKey(h => h.IdHabitacion);
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Recepcion>().HasKey(r => r.IdRecepcion);
            modelBuilder.Entity<Tarifa>().HasKey(t => t.IdTarifa);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Piso>().HasKey(p => p.IdPiso);
            modelBuilder.Entity<EstadoHabitacion>().HasKey(eh => eh.IdEstadoHabitacion);
            modelBuilder.Entity<RolUsuario>().HasKey(ru => ru.IdRolUsuario);
            modelBuilder.Entity<Servicio>().HasKey(s => s.IdServicio);
        }
    }
}
