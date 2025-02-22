using Microsoft.EntityFrameworkCore;
using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Cliente;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Entities.Recepcion;
using SGRH.Domain.Entities.Servicios;

namespace SGRH.Persistence.Context
{
    public class SGRHContext : DbContext
    {
        public SGRHContext(DbContextOptions<SGRHContext> options) : base(options)
        {
        }

        // Representación de las tablas en la base de datos :)
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
    }
}

