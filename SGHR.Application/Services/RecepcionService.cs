using SGHR.Application.Dtos.Recepcion;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;

namespace SGHR.Application.Services;

public class RecepcionService(IRecepcionRepository recepcionRepository) : IRecepcionService
{
    private readonly IRecepcionRepository _recepcionRepository = recepcionRepository;

    public async Task<IEnumerable<RecepcionDto>> GetAllAsync()
    {
        var recepciones = await _recepcionRepository.GetAllAsync();
        return recepciones.Select(r => new RecepcionDto
        {
            IdRecepcion = r.IdRecepcion,
            IdCliente = r.IdCliente,
            IdHabitacion = r.IdHabitacion,
            FechaEntrada = r.FechaEntrada,
            FechaSalida = r.FechaSalida,
            TotalPagado = r.TotalPagado,
            Estado = r.Estado
        });
    }

    public async Task<RecepcionDto> GetByIdAsync(int id)
    {
        var recepcion = await _recepcionRepository.GetByIdAsync(id);
        if (recepcion == null)
            throw new KeyNotFoundException("Recepción no encontrada");

        return new RecepcionDto
        {
            IdRecepcion = recepcion.IdRecepcion,
            IdCliente = recepcion.IdCliente,
            IdHabitacion = recepcion.IdHabitacion,
            FechaEntrada = recepcion.FechaEntrada,
            FechaSalida = recepcion.FechaSalida,
            TotalPagado = recepcion.TotalPagado,
            Estado = recepcion.Estado
        };
    }

    public async Task<OperationResult> CreateAsync(SaveRecepcionDto dto)
    {
        var recepcion = new Recepcion
        {
            IdCliente = dto.IdCliente,
            IdHabitacion = dto.IdHabitacion,
            FechaEntrada = dto.FechaEntrada,
            FechaSalida = dto.FechaSalida,
            Adelanto = dto.Adelanto,
            Estado = true,
            FechaCreacion = DateTime.UtcNow
        };
        return await _recepcionRepository.AddAsync(recepcion);
    }

    public async Task<OperationResult> UpdateAsync(UpdateRecepcionDto dto)
    {
        var recepcion = await _recepcionRepository.GetByIdAsync(dto.IdRecepcion);
        if (recepcion == null)
            return new OperationResult { Success = false, Message = "Recepción no encontrada" };

        recepcion.FechaSalida = dto.FechaSalida;
        recepcion.TotalPagado = dto.TotalPagado;
        recepcion.Observacion = dto.Observacion;

        return await _recepcionRepository.UpdateAsync(recepcion);
    }

    public async Task<OperationResult> RemoveAsync(RemoveRecepcionDto dto)
    {
        var recepcion = await _recepcionRepository.GetByIdAsync(dto.IdRecepcion);
        if (recepcion == null)
            return new OperationResult { Success = false, Message = "Recepción no encontrada" };

        recepcion.Estado = false;
        return await _recepcionRepository.UpdateAsync(recepcion);
    }
}
