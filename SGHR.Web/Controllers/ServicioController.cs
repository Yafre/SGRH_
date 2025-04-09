using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Servicio;
using SGHR.Web.Services.Interfaces;

public class ServicioController : Controller
{
    private readonly IServicioApiService _servicioService;

    public ServicioController(IServicioApiService servicioService)
    {
        _servicioService = servicioService;
    }

    public async Task<IActionResult> Index()
    {
        var servicios = await _servicioService.GetAllAsync();
        return View(servicios);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(SaveServicioDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var response = await _servicioService.CreateAsync(dto);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Servicio creado correctamente." : "Error al crear el servicio.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var servicio = await _servicioService.GetByIdAsync(id);
        if (servicio == null) return NotFound();

        var dto = new UpdateServicioDto
        {
            IdServicio = servicio.IdServicio,
            Nombre = servicio.Nombre,
            Descripcion = servicio.Descripcion,
            Estado = servicio.Estado
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateServicioDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var response = await _servicioService.UpdateAsync(dto.IdServicio, dto);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Servicio actualizado correctamente." : "No se pudo actualizar el servicio.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var servicio = await _servicioService.GetByIdAsync(id);
        return servicio == null ? NotFound() : View(servicio);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var servicio = await _servicioService.GetByIdAsync(id);
        return servicio == null ? NotFound() : View(servicio);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _servicioService.DeleteAsync(id);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Servicio eliminado correctamente." : "Error al eliminar el servicio.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Activate(int id)
    {
        var response = await _servicioService.ActivateAsync(id);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Servicio activado correctamente." : "Error al activar el servicio.";

        return RedirectToAction(nameof(Index));
    }
}

