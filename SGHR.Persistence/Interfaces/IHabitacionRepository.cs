using SGHR.Domain.Repository;
using SGHR.Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Persistence.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        Task<OperationResult> GetAvailableRoomsAsync();
    }
}
