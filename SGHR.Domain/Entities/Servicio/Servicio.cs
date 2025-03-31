using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Entities
{
    [Table("Servicios")]
    public class Servicio
    {
        [Key]
        [Column("IdServicio")] // Cambio aquí: IdServicio (con 'd' minúscula)
        public int IdServicio { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Categoria> Categorias { get; set; } = [];
    }
}
