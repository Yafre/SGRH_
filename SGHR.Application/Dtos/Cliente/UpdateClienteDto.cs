using System.ComponentModel.DataAnnotations;

namespace SGHR.Application.Dtos.Cliente
{
    public class UpdateClienteDto
    {
        public int IdCliente { get; set; }

        [Required]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        public string Documento { get; set; } = string.Empty;

        [Required]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;

        public bool Estado { get; set; }
    }
}
