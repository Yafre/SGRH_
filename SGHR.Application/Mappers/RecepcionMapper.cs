using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Recepcion;

namespace SGHR.Application.Mappers
{
    public static class RecepcionMapper
    {
        public static RecepcionDto ToDto(Recepcion entidad) => new RecepcionDto
        {
            IdRecepcion = entidad.IdRecepcion,
            IdCliente = entidad.IdCliente,
            IdHabitacion = entidad.IdHabitacion,
            FechaEntrada = entidad.FechaEntrada,
            FechaSalida = entidad.FechaSalida,
            TotalPagado = entidad.TotalPagado,
            Estado = entidad.Estado,
            Fecha = entidad.FechaCreacion ?? DateTime.MinValue,
            Observacion = entidad.Observacion ?? ""
        };

        public static Recepcion ToEntity(SaveRecepcionDto dto) => new Recepcion
        {
            IdCliente = dto.IdCliente,
            IdHabitacion = dto.IdHabitacion,
            FechaEntrada = dto.FechaEntrada,
            FechaSalida = dto.FechaSalida,
            Adelanto = dto.Adelanto,
            TotalPagado = dto.TotalPagado,
            Observacion = dto.Observacion,
            Estado = dto.Estado,
            FechaCreacion = DateTime.UtcNow
        };

        public static void UpdateEntity(Recepcion entidad, UpdateRecepcionDto dto)
        {
            entidad.FechaSalida = dto.FechaSalida;
            entidad.TotalPagado = dto.TotalPagado;
            entidad.Observacion = dto.Observacion;
            entidad.Estado = dto.Estado;
        }
    }
}