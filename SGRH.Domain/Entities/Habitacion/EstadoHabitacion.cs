namespace SGRH.Domain.Entities.Habitacion
{
    public class EstadoHabitacion
    {
        public int IdEstadoHabitacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }

}
