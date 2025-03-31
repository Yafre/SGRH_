using Microsoft.AspNetCore.Mvc;
using SGHR.Web.Services;
using SGHR.Application.Dtos.Recepcion;


namespace SGHR.Web.Controllers
{
    public class RecepcionController : Controller
    {
        private readonly RecepcionApiService _recepcionService;

        public RecepcionController(RecepcionApiService recepcionService)
        {
            _recepcionService = recepcionService;
        }

        public async Task<IActionResult> Index()
        {
            var recepciones = await _recepcionService.GetAllAsync();
            return View(recepciones);
        }

        public async Task<IActionResult> Details(int id)
        {
            var recepcion = await _recepcionService.GetByIdAsync(id);
            if (recepcion == null)
                return NotFound();

            return View(recepcion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRecepcionDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _recepcionService.CreateAsync(dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo crear la recepción");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recepcion = await _recepcionService.GetByIdAsync(id);
            if (recepcion == null)
                return NotFound();

            var updateDto = new UpdateRecepcionDto
            {
                IdRecepcion = recepcion.IdRecepcion,
                Fecha = recepcion.Fecha,
                Observaciones = recepcion.Observaciones
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRecepcionDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _recepcionService.UpdateAsync(dto.IdRecepcion, dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo editar la recepción");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var recepcion = await _recepcionService.GetByIdAsync(id);
            if (recepcion == null)
                return NotFound();

            return View(recepcion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _recepcionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}