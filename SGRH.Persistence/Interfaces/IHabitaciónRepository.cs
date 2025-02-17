using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;

namespace SGRH.Persistence.Interfaces
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        Task<List<Habitacion>> GetHabitacionesDisponiblesAsync(DateTime inicio, DateTime fin, int categoriaId);
    }
}
