namespace SGHR.Model.Model
{
    public class ClienteGetModel
    {
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        public string NombreCompleto { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public bool Estado { get; set; }
    }
}
