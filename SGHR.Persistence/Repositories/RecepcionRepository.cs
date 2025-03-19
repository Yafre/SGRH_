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
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        private readonly ILogger<RecepcionRepository> _logger;
        private readonly IConfiguration _configuration;

        public RecepcionRepository(SGHRContext context, ILogger<RecepcionRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public new async Task<IEnumerable<RecepcionGetModel>> GetAllAsync()
        {
            return await _context.Recepciones
                .Select(r => new RecepcionGetModel
                {
                    IdRecepcion = r.IdRecepcion,
                    IdCliente = r.IdCliente,
                    IdHabitacion = r.IdHabitacion,
                    FechaEntrada = r.FechaEntrada,
                    FechaSalida = r.FechaSalida,
                    PrecioInicial = r.PrecioInicial,
                    Adelanto = r.Adelanto,
                    PrecioRestante = r.PrecioRestante,
                    TotalPagado = r.TotalPagado,
                    EstadoBool = r.Estado
                }).ToListAsync();
        }

        public new async Task<OperationResult> GetByIdAsync(int id)
        {
            var result = new OperationResult();
            try
            {
                var recepcion = await _context.Recepciones
                    .Where(r => r.IdRecepcion == id)
                    .Select(r => new RecepcionGetModel
                    {
                        IdRecepcion = r.IdRecepcion,
                        IdCliente = r.IdCliente,
                        IdHabitacion = r.IdHabitacion,
                        FechaEntrada = r.FechaEntrada,
                        FechaSalida = r.FechaSalida,
                        PrecioInicial = r.PrecioInicial,
                        Adelanto = r.Adelanto,
                        PrecioRestante = r.PrecioRestante,
                        TotalPagado = r.TotalPagado,
                        EstadoBool = r.Estado
                    }).FirstOrDefaultAsync();

                if (recepcion != null)
                {
                    result.Data = recepcion;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Recepción no encontrada.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la recepción: {Message}", ex.Message);
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la recepción.";
            }
            return result;
        }
    }
}
