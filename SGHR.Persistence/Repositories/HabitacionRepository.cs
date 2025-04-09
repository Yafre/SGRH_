using Microsoft.EntityFrameworkCore;
using SGHR.Domain.Base;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Base;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
    {
        public HabitacionRepository(SGHRContext context) : base(context) { }

        public async Task<OperationResult> ActivateAsync(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
                return new OperationResult { Success = false, Message = "Habitación no encontrada" };

            habitacion.Estado = true;
            return await UpdateAsync(habitacion);
        }
    }
}
