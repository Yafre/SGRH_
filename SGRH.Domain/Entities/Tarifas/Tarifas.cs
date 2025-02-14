namespace SGRH.Domain.Entities.Tarifas
{
    public class Tarifa
    {
        public int IdTarifa { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; }

        // Relaciones
        public required Habitaciones.Habitacion Habitacion { get; set; }
    }
}
