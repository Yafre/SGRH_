using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGHR.Application.Dtos.Commons;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Interfaces;
using SGHR.Persistence.Context;
using System.Linq;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController(IHabitacionService service, ILogger<HabitacionController> logger, SGHRContext context) : ControllerBase
    {
        private readonly IHabitacionService _service = service;
        private readonly ILogger<HabitacionController> _logger = logger;
        private readonly SGHRContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound($"Habitación con ID {id} no encontrada.") : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveHabitacionDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHabitacionDto dto)
        {
            dto.IdHabitacion = id;
            var result = await _service.UpdateAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveAsync(new RemoveHabitacionDto { IdHabitacion = id });
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpGet("estados")]
        public IActionResult GetEstados() => Ok(_context.EstadoHabitacion.Select(e => new DropdownDto { Id = e.IdEstadoHabitacion, Nombre = e.Descripcion }).ToList());

        [HttpGet("pisos")]
        public IActionResult GetPisos() => Ok(_context.Piso.Select(p => new DropdownDto { Id = p.IdPiso, Nombre = p.Descripcion }).ToList());

        [HttpGet("categorias")]
        public IActionResult GetCategorias() => Ok(_context.Categoria.Select(c => new DropdownDto { Id = c.IdCategoria, Nombre = c.Descripcion }).ToList());

        [HttpPut("activar/{id}")]
        public async Task<IActionResult> Activar(int id)
        {
            var result = await _service.ActivateAsync(id);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}