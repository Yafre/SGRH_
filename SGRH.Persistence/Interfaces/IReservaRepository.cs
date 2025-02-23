using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Repository;

namespace SGRH.Persistence.Interfaces
{
    public interface IReservaRepository : IBaseRepository<Reserva>
    {
        Task<List<Reserva>> GetReservasActivasAsync();
    }
}
