using SGHR.Application.Dtos.Commons;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Web.Services.Interfaces;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class HabitacionApiService : IHabitacionApiService
    {
        private readonly HttpClient _httpClient;

        public HabitacionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<HabitacionDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<HabitacionDto>>("api/habitacion") ?? [];
        }

        public async Task<HabitacionDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<HabitacionDto>($"api/habitacion/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync(SaveHabitacionDto dto)
        {
            return await _httpClient.PostAsJsonAsync("api/habitacion", dto);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateHabitacionDto dto)
        {
            return await _httpClient.PutAsJsonAsync($"api/habitacion/{id}", dto);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/habitacion/{id}");
        }

        public async Task<HttpResponseMessage> ActivateAsync(int id)
        {
            return await _httpClient.PutAsync($"api/habitacion/activar/{id}", null);
        }

        public async Task<List<DropdownDto>> GetEstadosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DropdownDto>>("api/habitacion/estados");
            return response ?? new();
        }

        public async Task<List<DropdownDto>> GetPisosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DropdownDto>>("api/habitacion/pisos");
            return response ?? new();
        }

        public async Task<List<DropdownDto>> GetCategoriasAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DropdownDto>>("api/habitacion/categorias");
            return response ?? new();
        }
    }
}
