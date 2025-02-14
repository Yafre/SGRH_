namespace SGRH.Domain.Entities.Clientes
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public required string TipoDocumento { get; set; }
        public required string Documento { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public virtual ICollection<Recepciones.Recepcion> Recepciones { get; set; } = new List<Recepciones.Recepcion>();
    }
}
