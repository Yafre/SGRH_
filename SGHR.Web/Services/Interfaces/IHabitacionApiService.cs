using SGHR.Application.Dtos.Commons;
using SGHR.Application.Dtos.Habitacion;
using System.Net.Http;

namespace SGHR.Web.Services.Interfaces
{
    public interface IHabitacionApiService
    {
        Task<IEnumerable<HabitacionDto>> GetAllAsync();
        Task<HabitacionDto?> GetByIdAsync(int id);
        Task<HttpResponseMessage> CreateAsync(SaveHabitacionDto dto);
        Task<HttpResponseMessage> UpdateAsync(int id, UpdateHabitacionDto dto);
        Task<HttpResponseMessage> DeleteAsync(int id);
        Task<HttpResponseMessage> ActivateAsync(int id);
        Task<List<DropdownDto>> GetEstadosAsync();
        Task<List<DropdownDto>> GetPisosAsync();
        Task<List<DropdownDto>> GetCategoriasAsync();
    }
}
