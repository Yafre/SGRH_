using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Cliente;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(IClienteService clienteService, ILogger<ClienteController> logger) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;
        private readonly ILogger<ClienteController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetByIdAsync(id);
                return Ok(cliente);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveClienteDto dto)
        {
            var result = await _clienteService.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClienteDto dto)
        {
            dto.IdCliente = id;
            var result = await _clienteService.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteService.RemoveAsync(new RemoveClienteDto { IdCliente = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("activar/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            var result = await _clienteService.ActivateAsync(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
