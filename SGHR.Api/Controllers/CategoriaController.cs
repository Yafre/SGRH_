using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Commons;

namespace SGHR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = new List<DropdownDto>
            {
                new DropdownDto { Id = 1, Nombre = "Económica" },
                new DropdownDto { Id = 2, Nombre = "Estándar" },
                new DropdownDto { Id = 3, Nombre = "Deluxe" }
            };

            return Ok(categorias);
        }
    }
}
