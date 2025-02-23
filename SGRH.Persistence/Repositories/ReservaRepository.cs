using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<ReservaRepository> _logger;
        private readonly IConfiguration _configuration;

        public ReservaRepository(SGRHContext context, ILogger<ReservaRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<List<Reserva>> GetReservasActivasAsync()
        {
            _logger.LogInformation("Obteniendo todas las reservas activas");
            return await _context.Reservas
                                 .Where(r => r.Estado == true)
                                 .ToListAsync();
        }

        public async override Task<List<Reserva>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todas las reservas");
            return await _context.Reservas.ToListAsync();
        }
    }
}
