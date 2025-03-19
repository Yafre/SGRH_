using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGHR.Application.Dtos.Cliente;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Application.Interfaces;
using SGHR.Persistence.Interfaces;

namespace SGHR.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
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
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente no encontrado");

            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                NombreCompleto = cliente.NombreCompleto,
                Correo = cliente.Correo,
                Estado = cliente.Estado
            };
        }

        public async Task<OperationResult> CreateAsync(SaveClienteDto dto)
        {
            var cliente = new Cliente
            {
                NombreCompleto = dto.NombreCompleto,
                Correo = dto.Correo,
                Estado = true,
                FechaCreacion = DateTime.UtcNow
            };
            return await _clienteRepository.AddAsync(cliente);
        }

        public async Task<OperationResult> UpdateAsync(UpdateClienteDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(dto.IdCliente);
            if (cliente == null)
                return new OperationResult { Success = false, Message = "Cliente no encontrado" };

            cliente.NombreCompleto = dto.NombreCompleto;
            cliente.Correo = dto.Correo;
            return await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<OperationResult> RemoveAsync(RemoveClienteDto dto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(dto.IdCliente);  
            if (cliente == null)
                return new OperationResult { Success = false, Message = "Cliente no encontrado" };

            cliente.Estado = false; 
            return await _clienteRepository.UpdateAsync(cliente);
        }
    }
}
