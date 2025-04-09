// HabitacionController.cs
using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Web.Models;
using SGHR.Web.Services.Interfaces;

namespace SGHR.Web.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly IHabitacionApiService _habitacionService;

        public HabitacionController(IHabitacionApiService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        public async Task<IActionResult> Index()
        {
            var habitaciones = await _habitacionService.GetAllAsync();
            return View(habitaciones);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new HabitacionFormViewModel
            {
                Habitacion = new UpdateHabitacionDto(),
                Estados = await _habitacionService.GetEstadosAsync(),
                Pisos = await _habitacionService.GetPisosAsync(),
                Categorias = await _habitacionService.GetCategoriasAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HabitacionFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Estados = await _habitacionService.GetEstadosAsync();
                vm.Pisos = await _habitacionService.GetPisosAsync();
                vm.Categorias = await _habitacionService.GetCategoriasAsync();
                return View(vm);
            }

            var dto = new SaveHabitacionDto
            {
                Numero = vm.Habitacion.Numero,
                Detalle = vm.Habitacion.Detalle,
                Precio = vm.Habitacion.Precio,
                IdEstadoHabitacion = vm.Habitacion.IdEstadoHabitacion,
                IdPiso = vm.Habitacion.IdPiso,
                IdCategoria = vm.Habitacion.IdCategoria,
                Estado = vm.Habitacion.Estado
            };

            var response = await _habitacionService.CreateAsync(dto);
            if (response.IsSuccessStatusCode)
            {
                TempData["mensaje"] = "Habitación creada correctamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "No se pudo crear la habitación.";
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var habitacion = await _habitacionService.GetByIdAsync(id);
            if (habitacion == null) return NotFound();

            var vm = new HabitacionFormViewModel
            {
                Habitacion = new UpdateHabitacionDto
                {
                    IdHabitacion = habitacion.IdHabitacion,
                    Numero = habitacion.Numero,
                    Detalle = habitacion.Detalle,
                    Precio = habitacion.Precio,
                    Estado = habitacion.Estado,
                    IdCategoria = habitacion.IdCategoria,
                    IdPiso = habitacion.IdPiso,
                    IdEstadoHabitacion = habitacion.IdEstadoHabitacion
                },
                Estados = await _habitacionService.GetEstadosAsync(),
                Pisos = await _habitacionService.GetPisosAsync(),
                Categorias = await _habitacionService.GetCategoriasAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HabitacionFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Estados = await _habitacionService.GetEstadosAsync();
                vm.Pisos = await _habitacionService.GetPisosAsync();
                vm.Categorias = await _habitacionService.GetCategoriasAsync();
                return View(vm);
            }

            var dto = vm.Habitacion;
            var response = await _habitacionService.UpdateAsync(dto.IdHabitacion, dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["mensaje"] = "Habitación actualizada correctamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = "No se pudo actualizar la habitación.";
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var habitacion = await _habitacionService.GetByIdAsync(id);
            if (habitacion == null) return NotFound();
            return View(habitacion);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var habitacion = await _habitacionService.GetByIdAsync(id);
            if (habitacion == null) return NotFound();
            return View(habitacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(HabitacionDto model)
        {
            var response = await _habitacionService.DeleteAsync(model.IdHabitacion);

            TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
                response.IsSuccessStatusCode ? "Habitación desactivada correctamente." : "Hubo un problema al intentar desactivar la habitación.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activar(int id)
        {
            var response = await _habitacionService.ActivateAsync(id);

            TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
                response.IsSuccessStatusCode ? "Habitación activada correctamente." : "Hubo un problema al intentar activar la habitación.";

            return RedirectToAction(nameof(Index));
        }
    }
}
