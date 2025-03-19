using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Habitacion
{
    public class UpdateHabitacionDto : SaveHabitacionDto
    {
        public int IdHabitacion { get; set; }
    }

}
