using SGHR.Application.Dtos.Usuario;
using SGHR.Domain.Entities;

namespace SGHR.Application.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDto ToDto(Usuario entidad) => new UsuarioDto
        {
            IdUsuario = entidad.IdUsuario,
            NombreCompleto = entidad.NombreCompleto,
            Correo = entidad.Correo,
            Rol = entidad.RolUsuario?.Descripcion ?? "Sin Rol",
            IdRolUsuario = entidad.IdRolUsuario,
            Estado = entidad.Estado
        };

        public static Usuario ToEntity(SaveUsuarioDto dto) => new Usuario
        {
            NombreCompleto = dto.NombreCompleto,
            Correo = dto.Correo,
            IdRolUsuario = dto.IdRolUsuario,
            Estado = dto.Estado,
            FechaCreacion = DateTime.UtcNow
        };

        public static void UpdateEntity(Usuario entidad, UpdateUsuarioDto dto)
        {
            entidad.NombreCompleto = dto.NombreCompleto;
            entidad.Correo = dto.Correo;
            entidad.IdRolUsuario = dto.IdRolUsuario;
            entidad.Estado = dto.Estado;
        }
    }
}