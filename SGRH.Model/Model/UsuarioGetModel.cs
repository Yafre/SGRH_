namespace SGHR.Model.Model
{
    public class UsuarioGetModel
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }

        // Extras según tus errores
        public string NombreCompleto { get; set; }
        public int IdRolUsuario { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}