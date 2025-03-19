using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Usuario;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService service, ILogger<UsuarioController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound($"Usuario con ID {id} no encontrado.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveUsuarioDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioDto dto)
        {
            dto.IdUsuario = id;
            var result = await _service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(new RemoveUsuarioDto { IdUsuario = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
