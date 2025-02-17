namespace SGRH.Domain.Entities.Habitacion
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int IdServicio { get; set; } // Relación con Servicios
    }

}
