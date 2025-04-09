using SGHR.Application.Dtos.Cliente;
using SGHR.Model.Model;
using System.Net.Http;

namespace SGHR.Web.Services.Interfaces
{
    public interface IClienteApiService
    {
        Task<IEnumerable<ClienteGetModel>?> GetAllAsync();
        Task<ClienteGetModel?> GetByIdAsync(int id);
        Task<ClienteGetModel?> GetDetailedByIdAsync(int id);
        Task<HttpResponseMessage> CreateAsync(SaveClienteDto dto);
        Task<HttpResponseMessage> UpdateAsync(int id, UpdateClienteDto dto);
        Task<HttpResponseMessage> DeleteAsync(int id);
        Task<HttpResponseMessage> ActivateAsync(int id);
    }
}
