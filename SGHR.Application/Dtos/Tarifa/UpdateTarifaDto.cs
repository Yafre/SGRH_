using System;

namespace SGHR.Application.Dtos.Tarifa
{
    public class UpdateTarifaDto : SaveTarifaDto
    {
        public int IdTarifa { get; set; }
    }
}
