using SGHR.Domain.Entities;

namespace SGHR.Domain.Repository
{
    public interface ITarifaRepository : IBaseRepository<Tarifa>
    {
        Task<IEnumerable<Tarifa>> GetActiveTarifasAsync();
    }
}
