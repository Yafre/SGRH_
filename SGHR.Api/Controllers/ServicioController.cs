using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Servicio;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicioController(IServicioService service, ILogger<ServicioController> logger) : ControllerBase
{
    private readonly IServicioService _service = service;
    private readonly ILogger<ServicioController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound($"Servicio con ID {id} no encontrado.") : Ok(result);
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

    [HttpPut("activar/{id}")]
    public async Task<IActionResult> Activate(int id)
    {
        var servicio = await _service.GetByIdAsync(id);
        if (servicio == null) return NotFound("Servicio no encontrado.");

        var result = await _service.UpdateAsync(new UpdateServicioDto
        {
            IdServicio = id,
            Nombre = servicio.Nombre,
            Descripcion = servicio.Descripcion,
            Estado = true
        });

        return result.Success ? Ok(result) : BadRequest(result.Message);
    }
}
