using SGHR.Domain.Entities.Habitaciones;
using SGHR.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Recepcion
{
    [Key]
    public int IdRecepcion { get; set; }

    [ForeignKey(nameof(Cliente))]
    public int IdCliente { get; set; }  

    [ForeignKey(nameof(Habitacion))]
    public int IdHabitacion { get; set; }  

    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime? FechaSalidaConfirmacion { get; set; }

    public decimal PrecioInicial { get; set; }
    public decimal Adelanto { get; set; }
    public decimal PrecioRestante { get; set; }
    public decimal TotalPagado { get; set; }
    public decimal CostoPenalidad { get; set; }
    public string Observacion { get; set; } = string.Empty;
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }

 
    public virtual Cliente Cliente { get; set; } = null!;
    public virtual Habitacion Habitacion { get; set; } = null!;
}
