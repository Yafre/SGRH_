namespace SGHR.Model.Model
{
    public class RecepcionGetModel
    {
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal Adelanto { get; set; }
        public decimal PrecioRestante { get; set; }
        public decimal TotalPagado { get; set; }

        public string Estado => EstadoBool ? "activo" : "inactivo";
        public bool EstadoBool { get; set; }
    }
}
