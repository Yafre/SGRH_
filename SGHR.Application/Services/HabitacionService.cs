using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionService(IHabitacionRepository habitacionRepository)
        {
            _habitacionRepository = habitacionRepository;
        }

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
                Estado = true,
                FechaCreacion = DateTime.UtcNow
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
    }
}
