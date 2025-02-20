﻿namespace SGRH.Domain.Entities.Cliente
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; } = string.Empty; // Para evitar una advertencia
        public string Documento { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }


}
