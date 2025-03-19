using SGHR.Domain.Entities;

namespace SGHR.Domain.Repository
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        Task<IEnumerable<Recepcion>> GetReservationsByClienteIdAsync(int clienteId);
    }
}
