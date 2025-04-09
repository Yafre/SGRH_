using SGHR.Application.Dtos.Cliente;
using SGHR.Model.Model;
using SGHR.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class ClienteApiService : IClienteApiService
    {
        private readonly HttpClient _httpClient;

        public ClienteApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ClienteGetModel>?> GetAllAsync()
            => await _httpClient.GetFromJsonAsync<IEnumerable<ClienteGetModel>>("api/Cliente");

        public async Task<ClienteGetModel?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Cliente/{id}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<ClienteGetModel>()
                : null;
        }

        public async Task<ClienteGetModel?> GetDetailedByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Cliente/{id}");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<ClienteGetModel>()
                : null;
        }

        public async Task<HttpResponseMessage> CreateAsync(SaveClienteDto dto)
            => await _httpClient.PostAsJsonAsync("api/Cliente", dto);

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateClienteDto dto)
            => await _httpClient.PutAsJsonAsync($"api/Cliente/{id}", dto);

        public async Task<HttpResponseMessage> DeleteAsync(int id)
            => await _httpClient.DeleteAsync($"api/Cliente/{id}");

        public async Task<HttpResponseMessage> ActivateAsync(int id)
            => await _httpClient.PutAsync($"api/Cliente/activar/{id}", null);
    }
}
