using SGHR.Application.Dtos.Usuario;
using System.Net.Http.Json;

namespace SGHR.Web.Services
{
    public class UsuarioApiService
    {
        private readonly HttpClient _httpClient;

        public UsuarioApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UsuarioDto>>("api/usuario");
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UsuarioDto>($"api/usuario/{id}");
        }

        public async Task<HttpResponseMessage> CreateAsync(SaveUsuarioDto dto)
        {
            return await _httpClient.PostAsJsonAsync("api/usuario", dto);
        }

        public async Task<HttpResponseMessage> UpdateAsync(int id, UpdateUsuarioDto dto)
        {
            return await _httpClient.PutAsJsonAsync($"api/usuario/{id}", dto);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/usuario/{id}");
        }
    }
}