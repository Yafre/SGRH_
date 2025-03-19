using SGHR.Domain.Entities;

namespace SGHR.Domain.Services
{
    public interface ITarifaService
    {
        Task<IEnumerable<Tarifa>> GetAllTarifasAsync();
        Task<IEnumerable<Tarifa>> GetActiveTarifasAsync();
        Task<Tarifa?> GetTarifaByIdAsync(int id);
        Task AddTarifaAsync(Tarifa tarifa);
        Task UpdateTarifaAsync(Tarifa tarifa);
        Task DeleteTarifaAsync(int id);
    }
}
