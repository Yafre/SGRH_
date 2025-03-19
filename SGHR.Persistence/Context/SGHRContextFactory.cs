using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SGHR.Persistence.Context
{
    public class SGHRContextFactory : IDesignTimeDbContextFactory<SGHRContext>
    {
        public SGHRContext CreateDbContext(string[] args)
        {
           
            var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName ?? "", "SGHR.Api");

            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException($"No se encontró el directorio SGHR.Api en la ruta: {basePath}");
            }

            var configPath = Path.Combine(basePath, "appsettings.json");
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"No se encontró el archivo de configuración: {configPath}");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("SGHRDb");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se pudo obtener la cadena de conexión 'SGHRDb'. Verifica appsettings.json.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<SGHRContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SGHRContext(optionsBuilder.Options);
        }
    }
}
