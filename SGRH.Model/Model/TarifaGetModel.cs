namespace SGHR.Model.Model
{
    public class TarifaGetModel
    {
        public int IdTarifa { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public string Estado => EstadoBool ? "activo" : "inactivo";
        public bool EstadoBool { get; set; }
    }
}
