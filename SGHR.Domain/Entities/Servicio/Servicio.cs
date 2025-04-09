using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Domain.Entities.Servicios
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;

        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
