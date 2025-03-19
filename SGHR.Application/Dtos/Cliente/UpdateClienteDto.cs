using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SGHR.Application.Dtos.Cliente
{
    public class UpdateClienteDto : SaveClienteDto
    {
        public int IdCliente { get; set; }
    }

}
