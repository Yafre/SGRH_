using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<HabitacionRepository> _logger;
        private readonly IConfiguration _configuration;

        public HabitacionRepository(SGRHContext context,
                                     ILogger<HabitacionRepository> logger,
                                     IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<List<Habitacion>> GetHabitacionesDisponiblesAsync(DateTime inicio, DateTime fin, int categoriaId)
        {
            _logger.LogInformation($"Obteniendo habitaciones disponibles para la categoría {categoriaId} entre {inicio} y {fin}");
            return await _context.Habitaciones
                                 .Where(h => h.IdCategoria == categoriaId &&
                                             !h.Reservas.Any(r => r.FechaInicio < fin && r.FechaFin > inicio))
                                 .ToListAsync();
        }

        public async override Task<List<Habitacion>> GetAllAsync()
        {
            _logger.LogInformation("Obteniendo todas las habitaciones activas");
            return await _context.Habitaciones
                                 .Where(h => h.Estado == true)
                                 .ToListAsync();
        }
    }
}
