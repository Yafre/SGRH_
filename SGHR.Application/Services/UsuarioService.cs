using SGHR.Application.Dtos.Usuario;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(u => new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                NombreCompleto = u.NombreCompleto,
                Correo = u.Correo,
                Estado = u.Estado
            });
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuario no encontrado");

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                Estado = usuario.Estado
            };
        }

        public async Task<OperationResult> CreateAsync(SaveUsuarioDto dto)
        {
            var usuario = new Usuario
            {
                NombreCompleto = dto.NombreCompleto,
                Correo = dto.Correo,
                Estado = true
            };
            return await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<OperationResult> UpdateAsync(UpdateUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null)
                return new OperationResult { Success = false, Message = "Usuario no encontrado" };

            usuario.NombreCompleto = dto.NombreCompleto;
            usuario.Correo = dto.Correo;
            return await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task<OperationResult> RemoveAsync(RemoveUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null)
                return new OperationResult { Success = false, Message = "Usuario no encontrado" };

            usuario.Estado = false;
            return await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
