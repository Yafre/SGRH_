using SGHR.Application.Dtos.Tarifa;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class TarifaApiService
    {
        private readonly HttpClient _httpClient;

        public TarifaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TarifaDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TarifaDto>>("api/tarifa");
        }

        public async Task<TarifaDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TarifaDto>($"api/tarifa/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync(SaveTarifaDto dto)
        {
            return await _httpClient.PostAsJsonAsync("api/tarifa", dto);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateTarifaDto dto)
        {
            return await _httpClient.PutAsJsonAsync($"api/tarifa/{id}", dto);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/tarifa/{id}");
        }
    }
}