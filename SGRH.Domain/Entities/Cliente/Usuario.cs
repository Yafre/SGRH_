namespace SGRH.Domain.Entities.Cliente
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int? IdRolUsuario { get; set; } // Relación con RolUsuario
        public string Clave { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }

}
