namespace SGHR.Model.Model
{
    public class UsuarioGetModel
    {
        public int IdUsuario { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public int IdRolUsuario { get; set; } 
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
