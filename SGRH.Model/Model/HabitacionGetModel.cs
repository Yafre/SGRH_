namespace SGHR.Model.Model
{
    public class HabitacionGetModel
    {
        public int IdHabitacion { get; set; }
        public required string Numero { get; set; }
        public required string Detalle { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
