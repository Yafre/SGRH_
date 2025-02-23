using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities.Cliente;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Entities.Recepcion;
using SGRH.Domain.Entities.Servicios;

namespace SGRH.Persistence.Context
{
    public class SGRHContext : DbContext
    {
        public SGRHContext(DbContextOptions<SGRHContext> options) : base(options) { }

        // Representación de las tablas en la base de datos
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Reserva> Reservas { get; set; } // Agregamos Reserva

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir claves primarias
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Habitacion>().HasKey(h => h.IdHabitacion);
            modelBuilder.Entity<Recepcion>().HasKey(r => r.IdRecepcion);
            modelBuilder.Entity<Servicios>().HasKey(s => s.IdServicio);
            modelBuilder.Entity<Reserva>().HasKey(r => r.IdReserva); // Clave primaria de Reserva

            // 🔹 Configurar relaciones entre Reserva, Habitacion y Cliente
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Habitacion)
                .WithMany(h => h.Reservas) // Asegúrate de que `Habitacion` tenga `public ICollection<Reserva> Reservas { get; set; }`
                .HasForeignKey(r => r.IdHabitacion)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas) // Asegúrate de que `Cliente` tenga `public ICollection<Reserva> Reservas { get; set; }`
                .HasForeignKey(r => r.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

