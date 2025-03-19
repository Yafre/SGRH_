using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Servicio;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _service;
        private readonly ILogger<ServicioController> _logger;

        public ServicioController(IServicioService service, ILogger<ServicioController> logger)
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
            if (result == null) return NotFound($"Servicio con ID {id} no encontrado.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveServicioDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServicioDto dto)
        {
            dto.IdServicio = id;
            var result = await _service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(new RemoveServicioDto { IdServicio = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
