namespace SGRH.Domain.Entities.Usuarios
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public required string Clave { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public required RolUsuario RolUsuario { get; set; }
    }
}
