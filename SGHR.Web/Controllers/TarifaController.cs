using Microsoft.AspNetCore.Mvc;
using SGHR.Web.Services;
using SGHR.Application.Dtos.Tarifa;

namespace SGHR.Web.Controllers
{
    public class TarifaController : Controller
    {
        private readonly TarifaApiService _tarifaService;

        public TarifaController(TarifaApiService tarifaService)
        {
            _tarifaService = tarifaService;
        }

        public async Task<IActionResult> Index()
        {
            var tarifas = await _tarifaService.GetAllAsync();
            return View(tarifas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var tarifa = await _tarifaService.GetByIdAsync(id);
            if (tarifa == null)
                return NotFound();

            return View(tarifa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTarifaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _tarifaService.CreateAsync(dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo crear la tarifa");
            return View(dto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tarifa = await _tarifaService.GetByIdAsync(id);
            if (tarifa == null)
                return NotFound();

            var updateDto = new UpdateTarifaDto
            {
                IdTarifa = tarifa.IdTarifa,
                Nombre = tarifa.Nombre,
                Precio = tarifa.Precio
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTarifaDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var response = await _tarifaService.UpdateAsync(dto.IdTarifa, dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "No se pudo editar la tarifa");
            return View(dto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tarifa = await _tarifaService.GetByIdAsync(id);
            if (tarifa == null)
                return NotFound();

            return View(tarifa);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _tarifaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
