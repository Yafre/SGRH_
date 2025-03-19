using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Repository
{
    public interface IHabitacionRepository : IBaseRepository<Habitacion>
    {
        Task<IEnumerable<Habitacion>> GetAvailableRoomsAsync();
    }
}
