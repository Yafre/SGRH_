using SGHR.Application.Dtos.Cliente;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Model.Model;
using SGHR.Persistence.Interfaces;

namespace SGHR.Application.Services;

public class ClienteService(IClienteRepository clienteRepository) : IClienteService
{
    private readonly IClienteRepository _clienteRepository = clienteRepository;

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _clienteRepository.GetAllClientesAsync();
        return clientes.Select(c => new ClienteDto
        {
            IdCliente = c.IdCliente,
            NombreCompleto = c.NombreCompleto,
            Correo = c.Correo,
            Estado = c.Estado
        });
    }

    public async Task<ClienteDto> GetByIdAsync(int id)
    {
        var result = await _clienteRepository.GetClienteViewByIdAsync(id);
        if (!result.Success || result.Data is not ClienteGetModel cliente)
            throw new KeyNotFoundException(result.Message);

        return new ClienteDto
        {
            IdCliente = cliente.IdCliente,
            NombreCompleto = cliente.NombreCompleto,
            Correo = cliente.Correo,
            Estado = cliente.Estado
        };
    }

    public async Task<ClienteGetModel> GetDetailedByIdAsync(int id)
    {
        var result = await _clienteRepository.GetClienteViewByIdAsync(id);
        if (!result.Success || result.Data is not ClienteGetModel cliente)
            throw new KeyNotFoundException(result.Message);

        return cliente;
    }

    public async Task<OperationResult> CreateAsync(SaveClienteDto dto)
    {
        var cliente = new Cliente
        {
            TipoDocumento = dto.TipoDocumento,
            Documento = dto.Documento,
            NombreCompleto = dto.NombreCompleto,
            Correo = dto.Correo,
            Estado = dto.Estado,
            FechaCreacion = DateTime.UtcNow
        };
        return await _clienteRepository.AddAsync(cliente);
    }

    public async Task<OperationResult> UpdateAsync(UpdateClienteDto dto)
    {
        var cliente = await _clienteRepository.FindEntityByIdAsync(dto.IdCliente);
        if (cliente == null)
            return new OperationResult { Success = false, Message = "Cliente no encontrado." };

        cliente.TipoDocumento = dto.TipoDocumento;
        cliente.Documento = dto.Documento;
        cliente.NombreCompleto = dto.NombreCompleto;
        cliente.Correo = dto.Correo;
        cliente.Estado = dto.Estado;

        return await _clienteRepository.UpdateAsync(cliente);
    }

    public async Task<OperationResult> RemoveAsync(RemoveClienteDto dto)
    {
        return await _clienteRepository.DeleteClienteAsync(dto.IdCliente);
    }

    public async Task<OperationResult> ActivateAsync(int id)
    {
        return await _clienteRepository.ActivateAsync(id);
    }
}
