using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Recepcion
{
    public class SaveRecepcionDto
    {
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal Adelanto { get; set; }
        public decimal PrecioRestante { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal CostoPenalidad { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }

}

