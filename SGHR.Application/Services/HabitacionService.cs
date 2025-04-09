using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Interfaces;

namespace SGHR.Application.Services;

public class HabitacionService(IHabitacionRepository habitacionRepository) : IHabitacionService
{
    private readonly IHabitacionRepository _habitacionRepository = habitacionRepository;

    public async Task<IEnumerable<HabitacionDto>> GetAllAsync()
    {
        var habitaciones = await _habitacionRepository.GetAllAsync();
        return habitaciones.Select(h => new HabitacionDto
        {
            IdHabitacion = h.IdHabitacion,
            Numero = h.Numero,
            Detalle = h.Detalle,
            Precio = h.Precio,
            Estado = h.Estado
        });
    }

    public async Task<HabitacionDto> GetByIdAsync(int id)
    {
        var habitacion = await _habitacionRepository.GetByIdAsync(id);
        if (habitacion == null)
            throw new KeyNotFoundException("Habitación no encontrada");

        return new HabitacionDto
        {
            IdHabitacion = habitacion.IdHabitacion,
            Numero = habitacion.Numero,
            Detalle = habitacion.Detalle,
            Precio = habitacion.Precio,
            Estado = habitacion.Estado
        };
    }

    public async Task<OperationResult> CreateAsync(SaveHabitacionDto dto)
    {
        var habitacion = new Habitacion
        {
            Numero = dto.Numero,
            Detalle = dto.Detalle,
            Precio = dto.Precio,
            Estado = dto.Estado,
            FechaCreacion = DateTime.UtcNow,
            IdCategoria = dto.IdCategoria,
            IdPiso = dto.IdPiso,
            IdEstadoHabitacion = dto.IdEstadoHabitacion
        };
        return await _habitacionRepository.AddAsync(habitacion);
    }

    public async Task<OperationResult> UpdateAsync(UpdateHabitacionDto dto)
    {
        var habitacion = await _habitacionRepository.GetByIdAsync(dto.IdHabitacion);
        if (habitacion == null)
            return new OperationResult { Success = false, Message = "Habitación no encontrada" };

        habitacion.Numero = dto.Numero;
        habitacion.Detalle = dto.Detalle;
        habitacion.Precio = dto.Precio;
        habitacion.IdPiso = dto.IdPiso;
        habitacion.IdCategoria = dto.IdCategoria;
        habitacion.IdEstadoHabitacion = dto.IdEstadoHabitacion;
        habitacion.Estado = dto.Estado;

        return await _habitacionRepository.UpdateAsync(habitacion);
    }

    public async Task<OperationResult> RemoveAsync(RemoveHabitacionDto dto)
    {
        var habitacion = await _habitacionRepository.GetByIdAsync(dto.IdHabitacion);
        if (habitacion == null)
            return new OperationResult { Success = false, Message = "Habitación no encontrada" };

        habitacion.Estado = false;
        return await _habitacionRepository.UpdateAsync(habitacion);
    }

    public async Task<OperationResult> ActivateAsync(int id)
    {
        var habitacion = await _habitacionRepository.GetByIdAsync(id);
        if (habitacion == null)
            return new OperationResult { Success = false, Message = "Habitación no encontrada" };

        habitacion.Estado = true;
        return await _habitacionRepository.UpdateAsync(habitacion);
    }
}
