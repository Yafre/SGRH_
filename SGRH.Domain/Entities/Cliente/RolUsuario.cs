namespace SGRH.Domain.Entities.Cliente
{
    public class RolUsuario
    {
        public int IdRolUsuario { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }

}
