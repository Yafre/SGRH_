namespace SGHR.Application.Dtos.Habitacion
{
    public class HabitacionDto
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool Estado { get; set; }

        public int IdEstadoHabitacion { get; set; }
        public int IdPiso { get; set; }
        public int IdCategoria { get; set; }
    }
}

