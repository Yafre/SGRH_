using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Tarifa;

namespace SGHR.Application.Mappers
{
    public static class TarifaMapper
    {
        public static TarifaDto ToDto(Tarifa entidad) => new TarifaDto
        {
            IdTarifa = entidad.IdTarifa,
            IdHabitacion = entidad.IdHabitacion,
            FechaInicio = entidad.FechaInicio,
            FechaFin = entidad.FechaFin,
            PrecioPorNoche = entidad.PrecioPorNoche
        };

        public static Tarifa ToEntity(SaveTarifaDto dto) => new Tarifa
        {
            IdHabitacion = dto.IdHabitacion,
            FechaInicio = dto.FechaInicio,
            FechaFin = dto.FechaFin,
            PrecioPorNoche = dto.PrecioPorNoche
        };

        public static void UpdateEntity(Tarifa entidad, UpdateTarifaDto dto)
        {
            entidad.IdHabitacion = dto.IdHabitacion;
            entidad.FechaInicio = dto.FechaInicio;
            entidad.FechaFin = dto.FechaFin;
            entidad.PrecioPorNoche = dto.PrecioPorNoche;
        }
    }
}