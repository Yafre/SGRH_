using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGRH.Domain.Entities.Habitacion;
using SGRH.Domain.Entities.Cliente; // 🔹 Asegúrate de importar correctamente el espacio de nombres

namespace SGRH.Domain.Entities.Habitacion
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Estado { get; set; } = true;

        // 🔹 Relación con Habitacion y Cliente
        [ForeignKey("IdHabitacion")]
        public virtual Habitacion? Habitacion { get; set; }

        [ForeignKey("IdCliente")]
        public virtual SGRH.Domain.Entities.Cliente.Cliente? Cliente { get; set; } // 🔹 Se agrega el namespace completo
    }
}
