namespace SGHR.Application.Dtos.Usuario
{
    public class SaveUsuarioDto
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public int IdRolUsuario { get; set; }  
        public bool Estado { get; set; }
    }
}