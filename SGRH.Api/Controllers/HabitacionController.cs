using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Persistence.Interfaces;

namespace SGRH.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly ILogger<HabitacionController> _logger;

        public HabitacionController(IHabitacionRepository habitacionRepository, ILogger<HabitacionController> logger)
        {
            _habitacionRepository = habitacionRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Obteniendo todas las habitaciones...");
            var habitaciones = await _habitacionRepository.GetAllAsync();
            return Ok(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo habitación con ID {id}...");
            var habitacion = await _habitacionRepository.GetEntityByIdAsync(id);

            if (habitacion == null)
            {
                _logger.LogWarning($"Habitación con ID {id} no encontrada.");
                return NotFound("Habitación no encontrada.");
            }

            return Ok(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Creando una nueva habitación: {habitacion.Numero}");
            var result = await _habitacionRepository.SaveEntityAsync(habitacion);

            if (!result.Success)
            {
                _logger.LogError($"Error al crear habitación: {result.Message}");
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = habitacion.IdHabitacion }, habitacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Habitacion habitacion)
        {
            if (!ModelState.IsValid || id != habitacion.IdHabitacion)
            {
                return BadRequest("Datos inválidos o ID no coincide.");
            }

            _logger.LogInformation($"Actualizando habitación con ID {id}...");
            var result = await _habitacionRepository.UpdateEntityAsync(habitacion);

            if (!result.Success)
            {
                _logger.LogError($"Error al actualizar habitación: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando habitación con ID {id}...");
            var habitacion = await _habitacionRepository.GetEntityByIdAsync(id);

            if (habitacion == null)
            {
                _logger.LogWarning($"Habitación con ID {id} no encontrada.");
                return NotFound("Habitación no encontrada.");
            }

            var result = await _habitacionRepository.DeleteEntityAsync(habitacion);

            if (!result.Success)
            {
                _logger.LogError($"Error al eliminar habitación: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
