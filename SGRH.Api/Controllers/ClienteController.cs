using Microsoft.AspNetCore.Mvc;
using SGRH.Domain.Entities.Cliente;
using SGRH.Persistence.Interfaces;

namespace SGRH.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteRepository clienteRepository, ILogger<ClienteController> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los clientes...");
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        // GET: api/Cliente/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo cliente con ID {id}...");
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);

            if (cliente == null)
            {
                _logger.LogWarning($"Cliente con ID {id} no encontrado.");
                return NotFound("Cliente no encontrado.");
            }

            return Ok(cliente);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Creando un nuevo cliente: {cliente.NombreCompleto}");
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            if (!result.Success)
            {
                _logger.LogError($"Error al crear cliente: {result.Message}");
                return BadRequest(result.Message);
            }

            return CreatedAtAction(nameof(GetById), new { id = cliente.IdCliente }, cliente);
        }

        // PUT: api/Cliente/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid || id != cliente.IdCliente)
            {
                return BadRequest("Datos inválidos o ID no coincide.");
            }

            _logger.LogInformation($"Actualizando cliente con ID {id}...");
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

            if (!result.Success)
            {
                _logger.LogError($"Error al actualizar cliente: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        // DELETE: api/Cliente/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando cliente con ID {id}...");
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);

            if (cliente == null)
            {
                _logger.LogWarning($"Cliente con ID {id} no encontrado.");
                return NotFound("Cliente no encontrado.");
            }

            var result = await _clienteRepository.DeleteEntityAsync(cliente);

            if (!result.Success)
            {
                _logger.LogError($"Error al eliminar cliente: {result.Message}");
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
