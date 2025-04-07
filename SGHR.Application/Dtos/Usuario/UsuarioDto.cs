namespace SGHR.Application.Dtos.Usuario
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }             
        public int IdRolUsuario { get; set; }      
        public bool Estado { get; set; }
    }
}