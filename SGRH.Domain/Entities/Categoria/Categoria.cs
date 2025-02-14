namespace SGRH.Domain.Entities.Categorias
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public required string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public required Servicios.Servicio Servicio { get; set; }
        public virtual ICollection<Habitaciones.Habitacion> Habitaciones { get; set; } = new List<Habitaciones.Habitacion>();
    }
}
