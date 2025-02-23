using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SGRH.Domain.Entities.Habitacion;

namespace SGRH.Domain.Entities.Cliente
{
    public class Cliente
    {
        [Key]  // clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autoincremental
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; } = string.Empty; // Para evitar una advertencia
        public string Documento { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }


}
