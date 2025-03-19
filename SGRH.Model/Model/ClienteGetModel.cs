namespace SGHR.Model.Model
{
    public class ClienteGetModel
    {
        public int IdCliente { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public bool Estado { get; set; }


    }
}
