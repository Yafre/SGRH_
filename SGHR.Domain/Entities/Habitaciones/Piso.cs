using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities.Habitaciones
{
    public class Piso
    {
        [Key]
        public int IdPiso { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación con Habitaciones
        public virtual ICollection<Habitacion> Habitaciones { get; set; } = [];
    }
}
