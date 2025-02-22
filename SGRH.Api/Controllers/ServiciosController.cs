using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Entities.Servicios;
using SGRH.Persistence.Interfaces;
using Microsoft.Extensions.Logging;

namespace SGRH.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly ILogger<ServicioController> _logger;

        public ServicioController(IServicioRepository servicioRepository, ILogger<ServicioController> logger)
        {
            _servicioRepository = servicioRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los servicios...");
            var servicios = await _servicioRepository.GetAllAsync();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo servicio con ID {id}...");
            var servicio = await _servicioRepository.GetEntityByIdAsync(id);

            if (servicio == null)
            {
                _logger.LogWarning($"Servicio con ID {id} no encontrado.");
                return NotFound("Servicio no encontrado.");
            }

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Servicios servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Creando un nuevo servicio: {servicio.Nombre}");
            var result = await _servicioRepository.SaveEntityAsync(servicio);

            if (!result.Success)
            {
                _logger.LogError($"Error al crear servicio: {result.Message}");  
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = servicio.IdServicio }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Servicios servicio)
        {
            if (!ModelState.IsValid || id != servicio.IdServicio)
            {
                return BadRequest("Datos inválidos o ID no coincide.");
            }

            _logger.LogInformation($"Actualizando servicio con ID {id}...");
            var result = await _servicioRepository.UpdateEntityAsync(servicio);

            if (!result.Success)
            {
                _logger.LogError($"Error al actualizar servicio: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando servicio con ID {id}...");
            var servicio = await _servicioRepository.GetEntityByIdAsync(id);

            if (servicio == null)
            {
                _logger.LogWarning($"Servicio con ID {id} no encontrado.");
                return NotFound("Servicio no encontrado.");
            }

            var result = await _servicioRepository.DeleteEntityAsync(servicio);

            if (!result.Success)
            {
                _logger.LogError($"Error al eliminar servicio: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
