namespace SGHR.Application.Dtos.Usuario
{
    public class UpdateUsuarioDto
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdRolUsuario { get; set; }  
        public bool Estado { get; set; }
    }
}