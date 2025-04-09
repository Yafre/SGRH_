using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGHR.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string TipoDocumento { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        public string NombreCompleto { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public bool Estado { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public ICollection<Recepcion>? Recepciones { get; set; }
    }
}

