using SGHR.Application.Dtos.Servicio;
using System.Net.Http;

namespace SGHR.Web.Services.Interfaces
{
    public interface IServicioApiService
    {
        Task<IEnumerable<ServicioDto>?> GetAllAsync();
        Task<ServicioDto?> GetByIdAsync(int id);
        Task<HttpResponseMessage> CreateAsync(SaveServicioDto dto);
        Task<HttpResponseMessage> UpdateAsync(int id, UpdateServicioDto dto);
        Task<HttpResponseMessage> DeleteAsync(int id);
        Task<HttpResponseMessage> ActivateAsync(int id);
    }
}
