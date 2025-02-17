namespace SGRH.Domain.Entities.Servicios
{
    public class Servicios
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public bool Estado { get; set; } = true;
    }

}
