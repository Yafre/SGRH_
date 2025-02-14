namespace SGRH.Domain.Entities.Habitaciones
{
    public class EstadoHabitacion
    {
        public int IdEstadoHabitacion { get; set; }
        public required string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
