using SGHR.Application.Dtos.Usuario;
using SGHR.Application.Interfaces;
using SGHR.Application.Mappers;
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
            return usuarios.Select(UsuarioMapper.ToDto);
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                throw new KeyNotFoundException("Usuario no encontrado");

            return UsuarioMapper.ToDto(usuario);
        }

        public async Task<OperationResult> CreateAsync(SaveUsuarioDto dto)
        {
            var usuario = UsuarioMapper.ToEntity(dto);
            return await _usuarioRepository.AddAsync(usuario);
        }

        public async Task<OperationResult> UpdateAsync(UpdateUsuarioDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(dto.IdUsuario);
            if (usuario == null)
                return new OperationResult { Success = false, Message = "Usuario no encontrado" };

            UsuarioMapper.UpdateEntity(usuario, dto);
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