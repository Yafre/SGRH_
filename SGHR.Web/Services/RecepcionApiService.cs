using SGHR.Application.Dtos.Recepcion;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class RecepcionApiService
    {
        private readonly HttpClient _httpClient;

        public RecepcionApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RecepcionDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<RecepcionDto>>("api/recepcion");
        }

        public async Task<RecepcionDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<RecepcionDto>($"api/recepcion/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync(SaveRecepcionDto dto)
        {
            return await _httpClient.PostAsJsonAsync("api/recepcion", dto);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateRecepcionDto dto)
        {
            return await _httpClient.PutAsJsonAsync($"api/recepcion/{id}", dto);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/recepcion/{id}");
        }
    }
}