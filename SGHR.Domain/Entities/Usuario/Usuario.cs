using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int IdRolUsuario { get; set; }
        public string Clave { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual RolUsuario RolUsuario { get; set; } = null!;
    }
}
