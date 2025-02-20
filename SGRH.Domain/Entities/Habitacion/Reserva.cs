namespace SGRH.Domain.Entities.Habitacion
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdHabitacion { get; set; } // Relación con Habitación
        public int IdCliente { get; set; } // Relación con Cliente
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Estado { get; set; } = true;

        // Propiedad de navegación
        public virtual Habitacion? Habitacion { get; set; }
    }
}