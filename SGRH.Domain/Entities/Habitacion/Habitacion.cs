namespace SGRH.Domain.Entities.Habitacion
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int? IdEstadoHabitacion { get; set; } // Relación con EstadoHabitacion
        public int? IdPiso { get; set; } // Relación con Piso
        public int? IdCategoria { get; set; } // Relación con Categoria
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }

}
