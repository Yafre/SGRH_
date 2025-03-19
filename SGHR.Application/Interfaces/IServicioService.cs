﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGHR.Application.Base;
using SGHR.Application.Dtos.Recepcion;
using SGHR.Application.Dtos.Servicio;
using SGHR.Domain.Base;

namespace SGHR.Application.Interfaces
{
    public interface IServicioService : IBaseService<ServicioDto, SaveServicioDto, UpdateServicioDto, RemoveServicioDto>
    {
    }

}
