using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Recepcion;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;

namespace SGRH.Persistence.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        Task<bool> ValidarDisponibilidadAsync(int habitacionId, DateTime inicio, DateTime fin);
    }
}
