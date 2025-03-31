using Microsoft.AspNetCore.Mvc;
using SGHR.Web.Services;
using SGHR.Application.Dtos.Usuario;

namespace SGHR.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioApiService _usuarioService;

        public UsuarioController(UsuarioApiService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return View(usuarios);
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUsuarioDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _usuarioService.CreateAsync(dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo crear el usuario");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            var updateDto = new UpdateUsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                NombreUsuario = usuario.NombreUsuario,
                Correo = usuario.Correo,
                Rol = usuario.Rol
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUsuarioDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _usuarioService.UpdateAsync(dto.IdUsuario, dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo editar el usuario");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _usuarioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}