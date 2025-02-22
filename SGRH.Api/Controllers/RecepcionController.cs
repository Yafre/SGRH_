using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Entities.Recepcion;
using SGRH.Persistence.Interfaces;
using Microsoft.Extensions.Logging;

namespace SGRH.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionRepository _recepcionRepository;
        private readonly ILogger<RecepcionController> _logger;

        public RecepcionController(IRecepcionRepository recepcionRepository, ILogger<RecepcionController> logger)
        {
            _recepcionRepository = recepcionRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Obteniendo todas las recepciones...");
            var recepciones = await _recepcionRepository.GetAllAsync();
            return Ok(recepciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo recepción con ID {id}...");
            var recepcion = await _recepcionRepository.GetEntityByIdAsync(id);

            if (recepcion == null)
            {
                _logger.LogWarning($"Recepción con ID {id} no encontrada.");
                return NotFound("Recepción no encontrada.");
            }

            return Ok(recepcion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Recepcion recepcion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Creando una nueva recepción...");
            var result = await _recepcionRepository.SaveEntityAsync(recepcion);

            if (!result.Success)
            {
                _logger.LogError($"Error al crear recepción: {result.Message}");
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = recepcion.IdRecepcion }, recepcion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Recepcion recepcion)
        {
            if (!ModelState.IsValid || id != recepcion.IdRecepcion)
            {
                return BadRequest("Datos inválidos o ID no coincide.");
            }

            _logger.LogInformation($"Actualizando recepción con ID {id}...");
            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);

            if (!result.Success)
            {
                _logger.LogError($"Error al actualizar recepción: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando recepción con ID {id}...");
            var recepcion = await _recepcionRepository.GetEntityByIdAsync(id);

            if (recepcion == null)
            {
                _logger.LogWarning($"Recepción con ID {id} no encontrada.");
                return NotFound("Recepción no encontrada.");
            }

            var result = await _recepcionRepository.DeleteEntityAsync(recepcion);

            if (!result.Success)
            {
                _logger.LogError($"Error al eliminar recepción: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
