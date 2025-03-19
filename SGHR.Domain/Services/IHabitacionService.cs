using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Services
{
    public interface IHabitacionService
    {
        Task<IEnumerable<Habitacion>> GetAllHabitacionesAsync();
        Task<IEnumerable<Habitacion>> GetAvailableRoomsAsync();
        Task<Habitacion?> GetHabitacionByIdAsync(int id);
        Task AddHabitacionAsync(Habitacion habitacion);
        Task UpdateHabitacionAsync(Habitacion habitacion);
        Task DeleteHabitacionAsync(int id);
    }
}
