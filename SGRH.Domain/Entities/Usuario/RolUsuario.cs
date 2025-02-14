namespace SGRH.Domain.Entities.Usuarios
{
    public class RolUsuario
    {
        public int IdRolUsuario { get; set; }
        public required string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
