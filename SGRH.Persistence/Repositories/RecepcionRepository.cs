using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Recepcion;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<RecepcionRepository> _logger;
        private readonly IConfiguration _configuration;

        public RecepcionRepository(SGRHContext context,
                                    ILogger<RecepcionRepository> logger,
                                    IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> ValidarDisponibilidadAsync(int habitacionId, DateTime inicio, DateTime fin)
        {
            _logger.LogInformation($"Validando disponibilidad de la habitación {habitacionId} entre {inicio} y {fin}");
            return !await _context.Recepciones
                                  .AnyAsync(r => r.IdHabitacion == habitacionId &&
                                                 r.FechaEntrada < fin && r.FechaSalida > inicio);
        }

        public async override Task<List<Recepcion>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todas las recepciones activas");
            return await _context.Recepciones
                                 .Where(r => r.Estado == true)
                                 .ToListAsync();
        }
    }
}
