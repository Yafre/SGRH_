namespace SGRH.Domain.Entities.Habitacion
{
    public class Tarifas
    {
        public int IdTarifa { get; set; }
        public int IdHabitacion { get; set; } // Relación con Habitacion
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

}
