using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Commons;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var estados = new List<DropdownDto>
            {
                new DropdownDto { Id = 1, Nombre = "Disponible" },
                new DropdownDto { Id = 2, Nombre = "Ocupada" },
                new DropdownDto { Id = 3, Nombre = "Mantenimiento" }
            };

            return Ok(estados);
        }
    }
}
