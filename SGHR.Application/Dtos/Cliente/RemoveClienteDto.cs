﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGHR.Application.Dtos.Cliente
{
    public class RemoveClienteDto
    {
        public int IdCliente { get; set; }
        public bool Estado { get; set; } = false;
    }

}

