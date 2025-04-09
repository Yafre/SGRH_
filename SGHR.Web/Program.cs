using SGHR.Web.Services;
using SGHR.Web.Services.Interfaces;

namespace SGHR.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 👇 Base URL configurable (puedes agregarla en appsettings.json también)
            var apiBaseUrl = "https://localhost:5116/";

            // Registro de servicios API usando interfaces (DIP + DI)
            builder.Services.AddHttpClient<IClienteApiService, ClienteApiService>(client =>
                client.BaseAddress = new Uri(apiBaseUrl));

            builder.Services.AddHttpClient<IHabitacionApiService, HabitacionApiService>(client =>
                client.BaseAddress = new Uri(apiBaseUrl));

            builder.Services.AddHttpClient<IServicioApiService, ServicioApiService>(client =>
                client.BaseAddress = new Uri(apiBaseUrl));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
