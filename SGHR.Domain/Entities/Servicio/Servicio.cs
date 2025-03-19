using System.ComponentModel.DataAnnotations;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Entities
{
    public class Servicio
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Relación con Categoría
        public virtual ICollection<Categoria> Categorias { get; set; } = [];
    }
}
