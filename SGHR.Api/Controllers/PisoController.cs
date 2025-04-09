using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Commons;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var pisos = new List<DropdownDto>
            {
                new DropdownDto { Id = 1, Nombre = "Primer Piso" },
                new DropdownDto { Id = 2, Nombre = "Segundo Piso" },
                new DropdownDto { Id = 3, Nombre = "Tercer Piso" }
            };

            return Ok(pisos);
        }
    }
}
