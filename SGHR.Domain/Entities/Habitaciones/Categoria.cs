using SGHR.Domain.Entities.Habitaciones;
using SGHR.Domain.Entities.Servicios;

public class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Estas 3 propiedades estaban faltando:
    public string Descripcion { get; set; } = string.Empty;

    public bool Estado { get; set; }

    public int IdServicio { get; set; }  // FK

    // Propiedad de navegación
    public Servicio Servicio { get; set; } = null!;

    public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
}
