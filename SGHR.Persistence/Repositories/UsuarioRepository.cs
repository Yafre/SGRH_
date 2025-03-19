using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Model.Model;
using SGHR.Persistence.Base;
using SGHR.Persistence.Context;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioRepository(SGHRContext context, ILogger<UsuarioRepository> logger, IConfiguration configuration)
            : base(context)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public new async Task<IEnumerable<UsuarioGetModel>> GetAllAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioGetModel
                {
                    IdUsuario = u.IdUsuario,
                    NombreCompleto = u.NombreCompleto,
                    Correo = u.Correo,
                    IdRolUsuario = u.IdRolUsuario,
                    Estado = u.Estado,
                    FechaCreacion = u.FechaCreacion
                }).ToListAsync();
        }

        public new async Task<OperationResult> GetByIdAsync(int id)
        {
            var result = new OperationResult();
            try
            {
                var usuario = await _context.Usuarios
                    .Where(u => u.IdUsuario == id)
                    .Select(u => new UsuarioGetModel
                    {
                        IdUsuario = u.IdUsuario,
                        NombreCompleto = u.NombreCompleto,
                        Correo = u.Correo,
                        IdRolUsuario = u.IdRolUsuario,
                        Estado = u.Estado,
                        FechaCreacion = u.FechaCreacion
                    }).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    result.Data = usuario;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el usuario: {ex.Message}");
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el usuario.";
            }
            return result;
        }
    }
}
