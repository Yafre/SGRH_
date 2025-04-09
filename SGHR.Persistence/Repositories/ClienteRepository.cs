using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Model.Model;
using SGHR.Persistence.Base;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(SGHRContext context, ILogger<ClienteRepository> logger)
            : base(context)
        {
            _logger = logger;
        }

        
        public async Task<IEnumerable<ClienteGetModel>> GetAllClientesAsync()
        {
            return await _context.Clientes
                .Select(c => new ClienteGetModel
                {
                    IdCliente = c.IdCliente,
                    TipoDocumento = c.TipoDocumento,
                    Documento = c.Documento,
                    NombreCompleto = c.NombreCompleto,
                    Correo = c.Correo,
                    Estado = c.Estado
                }).ToListAsync();
        }

        
        public async Task<OperationResult> GetClienteViewByIdAsync(int id)
        {
            var result = new OperationResult();
            try
            {
                var cliente = await _context.Clientes
                    .Where(c => c.IdCliente == id)
                    .Select(c => new ClienteGetModel
                    {
                        IdCliente = c.IdCliente,
                        TipoDocumento = c.TipoDocumento,
                        Documento = c.Documento,
                        NombreCompleto = c.NombreCompleto,
                        Correo = c.Correo,
                        Estado = c.Estado
                    }).FirstOrDefaultAsync();

                if (cliente != null)
                {
                    result.Data = cliente;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el cliente: {Message}", ex.Message);
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el cliente.";
            }
            return result;
        }

     
        public async Task<Cliente?> FindEntityByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

      
        public async Task<OperationResult> GetByEmailAsync(string email)
        {
            var result = new OperationResult();
            try
            {
                var cliente = await _context.Clientes
                    .Where(c => c.Correo == email)
                    .Select(c => new ClienteGetModel
                    {
                        IdCliente = c.IdCliente,
                        TipoDocumento = c.TipoDocumento,
                        Documento = c.Documento,
                        NombreCompleto = c.NombreCompleto,
                        Correo = c.Correo,
                        Estado = c.Estado
                    })
                    .FirstOrDefaultAsync();

                if (cliente != null)
                {
                    result.Data = cliente;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado con ese correo.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el cliente por email: {Message}", ex.Message);
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el cliente por correo.";
            }
            return result;
        }

     
        public async Task<OperationResult> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return new OperationResult { Success = false, Message = "Cliente no encontrado." };
            }

            cliente.Estado = false;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Cliente eliminado lógicamente." };
        }

        public async Task<OperationResult> ActivateAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return new OperationResult { Success = false, Message = "Cliente no encontrado." };
            }

            cliente.Estado = true;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Cliente activado correctamente." };
        }
    }
}
