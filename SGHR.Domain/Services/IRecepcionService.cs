using SGHR.Domain.Entities;

namespace SGHR.Domain.Services
{
    public interface IRecepcionService
    {
        Task<IEnumerable<Recepcion>> GetAllReservacionesAsync();
        Task<IEnumerable<Recepcion>> GetReservationsByClienteIdAsync(int clienteId);
        Task<Recepcion?> GetRecepcionByIdAsync(int id);
        Task AddRecepcionAsync(Recepcion recepcion);
        Task UpdateRecepcionAsync(Recepcion recepcion);
        Task DeleteRecepcionAsync(int id);
    }
}
