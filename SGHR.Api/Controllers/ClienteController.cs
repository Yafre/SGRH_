using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Cliente;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteService service, ILogger<ClienteController> logger)
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
            if (result == null) return NotFound($"Cliente con ID {id} no encontrado.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveClienteDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClienteDto dto)
        {
            dto.IdCliente = id;
            var result = await _service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(new RemoveClienteDto { IdCliente = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}



