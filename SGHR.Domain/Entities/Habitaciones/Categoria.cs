using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities.Habitaciones
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación con Servicio
        public virtual Servicio? Servicio { get; set; }

        // Relación con Habitaciones
        public virtual ICollection<Habitacion> Habitaciones { get; set; } = [];
    }
}
