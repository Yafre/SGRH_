using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using SGHR.Persistence.Interfaces;

namespace SGHR.Persistence
{
    public static class PersistenceService
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de la base de datos con SQL Server
            services.AddDbContext<SGHRContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Registro de los repositorios en el contenedor de dependencias
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            services.AddScoped<ITarifaRepository, TarifaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

