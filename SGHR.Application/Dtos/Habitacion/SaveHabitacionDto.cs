using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Habitacion
{
    public class SaveHabitacionDto
    {
        [Required(ErrorMessage = "El número es obligatorio")]
        public string Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "El detalle es obligatorio")]
        public string Detalle { get; set; } = string.Empty;

        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required]
        public int IdEstadoHabitacion { get; set; }

        [Required]
        public int IdPiso { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        public bool Estado { get; set; } = true;
    }


}
