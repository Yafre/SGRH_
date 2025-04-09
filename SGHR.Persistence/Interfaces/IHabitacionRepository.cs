using SGHR.Domain.Base;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Domain.Repository;
using System.Threading.Tasks;

namespace SGHR.Persistence.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        Task<OperationResult> ActivateAsync(int id);
    }
}
