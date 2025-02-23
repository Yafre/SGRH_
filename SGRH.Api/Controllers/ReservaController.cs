using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Persistence.Interfaces;

namespace SGRH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<ReservaController> _logger;

        public ReservaController(IReservaRepository reservaRepository, ILogger<ReservaController> logger)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservas()
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservaById(int id)
        {
            var reserva = await _reservaRepository.GetEntityByIdAsync(id);
            if (reserva == null)
                return NotFound($"No se encontró la reserva con ID {id}");

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva nuevaReserva)
        {
            if (nuevaReserva == null)
                return BadRequest("Datos inválidos para crear la reserva.");

            await _reservaRepository.SaveEntityAsync(nuevaReserva);
            return CreatedAtAction(nameof(GetReservaById), new { id = nuevaReserva.IdReserva }, nuevaReserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(int id, [FromBody] Reserva reservaActualizada)
        {
            if (reservaActualizada == null || id != reservaActualizada.IdReserva)
                return BadRequest("Los datos de la reserva no son válidos.");

            await _reservaRepository.UpdateEntityAsync(reservaActualizada);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _reservaRepository.GetEntityByIdAsync(id);
            if (reserva == null)
                return NotFound($"No se encontró la reserva con ID {id}");

            await _reservaRepository.DeleteEntityAsync(reserva);
            return NoContent();
        }
    }
}
