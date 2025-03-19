using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Model.Model;
using SGHR.Persistence.Base;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class TarifaRepository : BaseRepository<Tarifa>, ITarifaRepository
    {
        private readonly ILogger<TarifaRepository> _logger;
        private readonly IConfiguration _configuration;

        public TarifaRepository(SGHRContext context, ILogger<TarifaRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public new async Task<IEnumerable<TarifaGetModel>> GetAllAsync()
        {
            return await _context.Tarifas
                .Select(t => new TarifaGetModel
                {
                    IdTarifa = t.IdTarifa,
                    IdHabitacion = t.IdHabitacion,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    PrecioPorNoche = t.PrecioPorNoche,
                    Descuento = t.Descuento,
                    Descripcion = t.Descripcion,
                    EstadoBool = t.Estado
                }).ToListAsync();
        }

        public new async Task<OperationResult> GetByIdAsync(int id)
        {
            var result = new OperationResult();
            try
            {
                var tarifa = await _context.Tarifas
                    .Where(t => t.IdTarifa == id)
                    .Select(t => new TarifaGetModel
                    {
                        IdTarifa = t.IdTarifa,
                        IdHabitacion = t.IdHabitacion,
                        FechaInicio = t.FechaInicio,
                        FechaFin = t.FechaFin,
                        PrecioPorNoche = t.PrecioPorNoche,
                        Descuento = t.Descuento,
                        Descripcion = t.Descripcion,
                        EstadoBool = t.Estado
                    }).FirstOrDefaultAsync();

                if (tarifa != null)
                {
                    result.Data = tarifa;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Tarifa no encontrada.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la tarifa: {Message}", ex.Message);
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la tarifa.";
            }
            return result;
        }
    }
}
