using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities
{
    public class RolUsuario
    {
        [Key]
        public int IdRolUsuario { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = [];
    }
}
