using Microsoft.Extensions.DependencyInjection;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Persistence.Repositories;
using SGHR.Web.Services;
using SGHR.Web.Services.Interfaces;

namespace SGHR.IOC.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Servicios de Aplicación
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IHabitacionService, HabitacionService>();
            services.AddScoped<IRecepcionService, RecepcionService>();
            services.AddScoped<IServicioService, ServicioService>();
            services.AddScoped<ITarifaService, TarifaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Repositorios de Persistencia
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped<ITarifaRepository, TarifaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Servicios que consumen la API (Web Layer)
            services.AddHttpClient<IClienteApiService, ClienteApiService>(client =>
                client.BaseAddress = new Uri("https://localhost:5116/"));

            services.AddHttpClient<IHabitacionApiService, HabitacionApiService>(client =>
                client.BaseAddress = new Uri("https://localhost:5116/"));

            services.AddHttpClient<IServicioApiService, ServicioApiService>(client =>
                client.BaseAddress = new Uri("https://localhost:5116/"));

            return services;
        }
    }
}
