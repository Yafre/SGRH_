namespace SGRH.Domain.Entities.Servicios
{
    public class Servicio
    {
        public int IdServicios { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
    }
}
