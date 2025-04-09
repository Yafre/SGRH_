using System.ComponentModel.DataAnnotations;

namespace SGHR.Application.Dtos.Servicio
{
    public class SaveServicioDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;

        public bool Estado { get; set; } = true;
    }
}
