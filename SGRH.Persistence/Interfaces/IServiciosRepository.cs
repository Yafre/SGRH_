using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Servicios;
using SGRH.Domain.Repository;
using SGRH.Persistence.Base;

namespace SGRH.Persistence.Interfaces
{
    public interface IServicioRepository : IBaseRepository<Servicios>
    {
        Task<List<Servicios>> GetServiciosActivosAsync();
    }
}
