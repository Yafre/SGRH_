using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Recepcion;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionService _service;
        private readonly ILogger<RecepcionController> _logger;

        public RecepcionController(IRecepcionService service, ILogger<RecepcionController> logger)
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
            if (result == null) return NotFound($"Recepción con ID {id} no encontrada.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveRecepcionDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRecepcionDto dto)
        {
            dto.IdRecepcion = id;
            var result = await _service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(new RemoveRecepcionDto { IdRecepcion = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}

