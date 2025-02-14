namespace SGRH.Domain.Entities.Habitaciones
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public required string Numero { get; set; }
        public required string Detalle { get; set; }
        public decimal Precio { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public required EstadoHabitacion EstadoHabitacion { get; set; }
        public required Pisos.Piso Piso { get; set; }
        public required Categorias.Categoria Categoria { get; set; }
    }
}
