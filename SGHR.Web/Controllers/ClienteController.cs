using Microsoft.AspNetCore.Mvc;
using SGHR.Application.Dtos.Cliente;
using SGHR.Web.Services.Interfaces;

namespace SGHR.Web.Controllers;

public class ClienteController : Controller
{
    private readonly IClienteApiService _clienteService;

    public ClienteController(IClienteApiService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteService.GetAllAsync();
        return View(clientes);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(SaveClienteDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var response = await _clienteService.CreateAsync(dto);
        if (response.IsSuccessStatusCode)
        {
            TempData["mensaje"] = "Cliente creado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError(string.Empty, "No se pudo crear el cliente.");
        return View(dto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null) return NotFound();

        var dto = new UpdateClienteDto
        {
            IdCliente = cliente.IdCliente,
            TipoDocumento = cliente.TipoDocumento,
            Documento = cliente.Documento,
            NombreCompleto = cliente.NombreCompleto,
            Correo = cliente.Correo,
            Estado = cliente.Estado
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateClienteDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        var response = await _clienteService.UpdateAsync(dto.IdCliente, dto);
        if (response.IsSuccessStatusCode)
        {
            TempData["mensaje"] = "Cliente actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError("", "No se pudo actualizar el cliente.");
        return View(dto);
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }
        catch
        {
            TempData["error"] = "No se pudo cargar los detalles del cliente.";
            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }
        catch
        {
            TempData["error"] = "No se pudo cargar la vista de eliminación.";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _clienteService.DeleteAsync(id);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Cliente eliminado correctamente." : "Error al eliminar el cliente.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Activar(int id)
    {
        var response = await _clienteService.ActivateAsync(id);
        TempData[response.IsSuccessStatusCode ? "mensaje" : "error"] =
            response.IsSuccessStatusCode ? "Cliente activado correctamente." : "Error al activar el cliente.";

        return RedirectToAction(nameof(Index));
    }
}
