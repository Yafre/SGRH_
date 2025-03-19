using SGHR.Application.Dtos.Tarifa;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public async Task<IEnumerable<TarifaDto>> GetAllAsync()
        {
            var tarifas = await _tarifaRepository.GetAllAsync();
            return tarifas.Select(t => new TarifaDto
            {
                IdTarifa = t.IdTarifa,
                IdHabitacion = t.IdHabitacion, 
                FechaInicio = t.FechaInicio,
                FechaFin = t.FechaFin,
                PrecioPorNoche = t.PrecioPorNoche
            });
        }

        public async Task<TarifaDto> GetByIdAsync(int id)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(id);
            if (tarifa == null)
                throw new KeyNotFoundException("Tarifa no encontrada");

            return new TarifaDto
            {
                IdTarifa = tarifa.IdTarifa,
                IdHabitacion = tarifa.IdHabitacion, 
                FechaInicio = tarifa.FechaInicio,
                FechaFin = tarifa.FechaFin,
                PrecioPorNoche = tarifa.PrecioPorNoche
            };
        }

        public async Task<OperationResult> CreateAsync(SaveTarifaDto dto)
        {
            var tarifa = new Tarifa
            {
                IdHabitacion = dto.IdHabitacion, 
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                PrecioPorNoche = dto.PrecioPorNoche
            };
            return await _tarifaRepository.AddAsync(tarifa);
        }

        public async Task<OperationResult> UpdateAsync(UpdateTarifaDto dto)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(dto.IdTarifa);
            if (tarifa == null)
                return new OperationResult { Success = false, Message = "Tarifa no encontrada" };

            tarifa.IdHabitacion = dto.IdHabitacion; 
            tarifa.FechaInicio = dto.FechaInicio;
            tarifa.FechaFin = dto.FechaFin;
            tarifa.PrecioPorNoche = dto.PrecioPorNoche;

            return await _tarifaRepository.UpdateAsync(tarifa);
        }

        public async Task<OperationResult> RemoveAsync(RemoveTarifaDto dto)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(dto.IdTarifa);
            if (tarifa == null)
                return new OperationResult { Success = false, Message = "Tarifa no encontrada" };

            tarifa.Estado = false; 
            return await _tarifaRepository.UpdateAsync(tarifa);
        }
    }
}
