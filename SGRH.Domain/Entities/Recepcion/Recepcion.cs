namespace SGRH.Domain.Entities.Recepcion
{
    public class Recepcion
    {
        public int IdRecepcion { get; set; }
        public int? IdCliente { get; set; } // Relación con Cliente
        public int? IdHabitacion { get; set; } // Relación con Habitacion
        public DateTime FechaEntrada { get; set; } = DateTime.Now;
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal Adelanto { get; set; }
        public decimal PrecioRestante { get; set; }
        public decimal TotalPagado { get; set; } = 0;
        public decimal CostoPenalidad { get; set; } = 0;
        public string Observacion { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
    }

}
