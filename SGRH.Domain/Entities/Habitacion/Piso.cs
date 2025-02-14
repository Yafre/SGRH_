namespace SGRH.Domain.Entities.Pisos
{
    public class Piso
    {
        public int IdPiso { get; set; }
        public required string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
