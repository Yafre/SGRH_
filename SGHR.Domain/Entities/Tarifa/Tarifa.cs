using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Entities
{
    public class Tarifa
    {
        [Key]
        public int IdTarifa { get; set; }

        [ForeignKey(nameof(Habitacion))]
        public int IdHabitacion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual Habitacion Habitacion { get; set; } = null!;
    }
}
