using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Usuario;
using SGHR.Application.Interfaces;

namespace SGHR.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController(IUsuarioService service, ILogger<UsuarioController> logger) : ControllerBase
{
    private readonly IUsuarioService _service = service;
    private readonly ILogger<UsuarioController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result == null ? NotFound($"Usuario con ID {id} no encontrado.") : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaveUsuarioDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result.Message);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioDto dto)
    {
        dto.IdUsuario = id;
        var result = await _service.UpdateAsync(dto);
        return result.Success ? Ok(result) : BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.RemoveAsync(new RemoveUsuarioDto { IdUsuario = id });
        return result.Success ? Ok(result) : BadRequest(result.Message);
    }
}
