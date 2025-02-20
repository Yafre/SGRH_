using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Entities.Servicios;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public class ServicioRepository : BaseRepository<Servicios>, IServicioRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        private readonly IConfiguration _configuration;

        public ServicioRepository(SGRHContext context,
                                   ILogger<ServicioRepository> logger,
                                   IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<List<Servicios>> GetServiciosActivosAsync()
        {
            _logger.LogInformation("Obteniendo todos los servicios activos");
            return await _context.Servicios
                                 .Where(s => s.Estado == true)
                                 .ToListAsync();
        }

        public async override Task<List<Servicios>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todos los servicios");
            return await _context.Servicios.ToListAsync();
        }
    }
}
