using Microsoft.Extensions.DependencyInjection;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Persistence.Repositories;

namespace SGHR.IOC.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // REGISTRO DE SERVICIOS (Application Layer)
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IHabitacionService, HabitacionService>();
            services.AddScoped<IRecepcionService, RecepcionService>();
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<ITarifaService, TarifaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // REGISTRO DE REPOSITORIOS (Persistence Layer)
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped<ITarifaRepository, TarifaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
