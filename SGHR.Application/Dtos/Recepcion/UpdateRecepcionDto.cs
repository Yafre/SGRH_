namespace SGHR.Application.Dtos.Recepcion
{
    public class UpdateRecepcionDto
    {
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal TotalPagado { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }  // ← Agrega esta
        public string Observaciones { get; set; } = string.Empty; // ← Y esta
    }
}