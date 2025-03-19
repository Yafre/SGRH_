using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly SGHRContext _context;
        private readonly ILogger<ServicioRepository> _logger;

        public ServicioRepository(SGHRContext context, ILogger<ServicioRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Servicio>> GetAllAsync()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Servicios.AnyAsync(s => s.IdServicio == id);
        }

        public async Task<OperationResult> AddAsync(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Servicio agregado correctamente." };
        }

        public async Task<OperationResult> UpdateAsync(Servicio servicio)
        {
            if (!await ExistsAsync(servicio.IdServicio))
                return new OperationResult { Success = false, Message = "Servicio no encontrado." };

            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Servicio actualizado correctamente." };
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
                return new OperationResult { Success = false, Message = "Servicio no encontrado." };

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return new OperationResult { Success = true, Message = "Servicio eliminado correctamente." };
        }
    }
}


