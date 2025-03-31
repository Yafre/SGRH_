namespace SGHR.Application.Dtos.Usuario
{
    public class SaveUsuarioDto
    {
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string NombreCompleto { get; set; }
        public bool Estado { get; set; }
    }
}