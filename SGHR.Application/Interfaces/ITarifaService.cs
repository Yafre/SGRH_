using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGHR.Application.Base;
using SGHR.Application.Dtos.Tarifa;
using SGHR.Domain.Base;

namespace SGHR.Application.Interfaces
{
    public interface ITarifaService : IBaseService<TarifaDto, SaveTarifaDto, UpdateTarifaDto, RemoveTarifaDto>
    {
    }

}
