namespace SGRH.Domain.Entities.Recepciones
{
    public class Recepcion
    {
        public int IdRecepcion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaSalidaConfirmacion { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal Adelanto { get; set; }
        public decimal PrecioRestante { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal CostoPenalidad { get; set; }
        public required string Observacion { get; set; }
        public required bool Estado { get; set; }

        // Relaciones
        public required Clientes.Cliente Cliente { get; set; }
        public required Habitaciones.Habitacion Habitacion { get; set; }
    }
}
