using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGHR.Domain.Entities.Habitaciones
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }

        public string Numero { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        // 🔥 Asegurar que las claves foráneas coincidan con la BD
        [ForeignKey(nameof(EstadoHabitacion))]
        public int IdEstadoHabitacion { get; set; }
        public virtual EstadoHabitacion EstadoHabitacion { get; set; } = null!;

        [ForeignKey(nameof(Piso))]
        public int IdPiso { get; set; }
        public virtual Piso Piso { get; set; } = null!;

        [ForeignKey(nameof(Categoria))]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; } = null!;

        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación con Tarifas
        public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
    }
}
