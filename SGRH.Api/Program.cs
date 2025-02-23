using Microsoft.EntityFrameworkCore;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;
using SGRH.Persistence.Repositories;

namespace SGRH.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SGRHContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBHotel")));

            // Registro de los repositorios
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();
            builder.Services.AddScoped<IRecepcionRepository, RecepcionRepository>();
            builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
            builder.Services.AddScoped<IReservaRepository, ReservaRepository>(); // 🔹 REGISTRAR RESERVA

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
