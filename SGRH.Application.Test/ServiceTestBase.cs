using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using SGHR.Persistence.Repositories;
using System;

namespace SGRH.Application.Test.Services
{
    public class ServiceTestBase : IDisposable
    {
        protected readonly SGHRContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ServiceTestBase()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SGHRContext>(options =>
                options.UseSqlServer("Server=DESKTOP-ECEFNK5;Database=DBHotel_Test;User Id=sa;Password=SAUCEBOYZ;MultipleActiveResultSets=true;TrustServerCertificate=True;"));

           
            services.AddScoped<IClienteRepository, ClienteRepository>();

            _serviceProvider = services.BuildServiceProvider();
            _context = _serviceProvider.GetRequiredService<SGHRContext>();

            _context.Database.EnsureCreated(); 
        }

        
        public T GetRequiredService<T>() where T : notnull
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); 
            _context.Dispose();
        }
    }
}
