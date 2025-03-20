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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGHRContext).Assembly);
        }
    }
}
