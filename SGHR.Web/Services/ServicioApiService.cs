using SGHR.Application.Dtos.Servicio;
using SGHR.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class ServicioApiService : IServicioApiService
    {
        private readonly HttpClient _httpClient;

        public ServicioApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ServicioDto>?> GetAllAsync()
            => await _httpClient.GetFromJsonAsync<IEnumerable<ServicioDto>>("api/Servicio");

        public async Task<ServicioDto?> GetByIdAsync(int id)
            => await _httpClient.GetFromJsonAsync<ServicioDto>($"api/Servicio/{id}");

        public async Task<HttpResponseMessage> CreateAsync(SaveServicioDto dto)
            => await _httpClient.PostAsJsonAsync("api/Servicio", dto);

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateServicioDto dto)
            => await _httpClient.PutAsJsonAsync($"api/Servicio/{id}", dto);

        public async Task<HttpResponseMessage> DeleteAsync(int id)
            => await _httpClient.DeleteAsync($"api/Servicio/{id}");

        public async Task<HttpResponseMessage> ActivateAsync(int id)
            => await _httpClient.PutAsync($"api/Servicio/activar/{id}", null);
    }
}
