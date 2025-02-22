using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGRH.Domain.Entities;
using SGRH.Domain.Entities.Cliente;
using SGRH.Persistence.Base;
using SGRH.Persistence.Context;
using SGRH.Persistence.Interfaces;

namespace SGRH.Persistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SGRHContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        private readonly IConfiguration _configuration;

        public ClienteRepository(SGRHContext context,
                                  ILogger<ClienteRepository> logger,
                                  IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override Task<OperationResult> SaveEntityAsync(Cliente entity)
        {
            // Lógica para guardar cliente
            _logger.LogInformation($"Guardando cliente: {entity.NombreCompleto}");
            return base.SaveEntityAsync(entity);
        }

        public override Task<OperationResult> UpdateEntityAsync(Cliente entity)
        {
            // Lógica para actualizar cliente
            _logger.LogInformation($"Actualizando cliente: {entity.NombreCompleto}");
            return base.UpdateEntityAsync(entity);
        }

        public async override Task<List<Cliente>> GetAllAsync()
        {
            // Solo clientes activos
            _logger.LogInformation("Obteniendo lista de clientes activos");
            return await _context.Clientes
                                 .Where(c => c.Estado == true)
                                 .ToListAsync();
        }
    }
}
