using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGHR.Domain.Base;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Model.Model;
using SGHR.Persistence.Base;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        private readonly ILogger<HabitacionRepository> _logger;
        private readonly IConfiguration _configuration;

        public HabitacionRepository(SGHRContext context, ILogger<HabitacionRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<IEnumerable<Habitacion>> GetAllAsync()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        public async Task<OperationResult> GetAvailableRoomsAsync()
        {
            var result = new OperationResult();
            try
            {
                var rooms = await _context.Habitaciones
                    .Where(h => h.Estado)
                    .Select(h => new HabitacionGetModel
                    {
                        IdHabitacion = h.IdHabitacion,
                        Numero = h.Numero,
                        Detalle = h.Detalle ?? "Sin detalle",
                        Precio = h.Precio,
                        Estado = h.Estado,
                        FechaCreacion = h.FechaCreacion == default ? DateTime.UtcNow : h.FechaCreacion
                    }).ToListAsync();

                result.Data = rooms;
                result.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener habitaciones disponibles.");
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo habitaciones disponibles.";
            }
            return result;
        }
    }
}


