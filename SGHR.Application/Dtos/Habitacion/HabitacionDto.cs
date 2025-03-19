using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Habitacion
{
    public class HabitacionDto
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public decimal Precio { get; set; } 
        public bool Estado { get; set; }
    }
}
