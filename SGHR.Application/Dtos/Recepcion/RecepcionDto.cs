using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Recepcion
{
    public class RecepcionDto
    {
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal TotalPagado { get; set; }
        public bool Estado { get; set; }
    }

}
