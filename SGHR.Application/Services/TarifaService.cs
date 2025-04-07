using SGHR.Application.Dtos.Tarifa;
using SGHR.Application.Interfaces;
using SGHR.Application.Mappers;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
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
            return tarifas.Select(TarifaMapper.ToDto);
        }

        public async Task<TarifaDto> GetByIdAsync(int id)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(id);
            if (tarifa == null)
                throw new KeyNotFoundException("Tarifa no encontrada");

            return TarifaMapper.ToDto(tarifa);
        }

        public async Task<OperationResult> CreateAsync(SaveTarifaDto dto)
        {
            var tarifa = TarifaMapper.ToEntity(dto);
            return await _tarifaRepository.AddAsync(tarifa);
        }

        public async Task<OperationResult> UpdateAsync(UpdateTarifaDto dto)
        {
            var tarifa = await _tarifaRepository.GetByIdAsync(dto.IdTarifa);
            if (tarifa == null)
                return new OperationResult { Success = false, Message = "Tarifa no encontrada" };

            TarifaMapper.UpdateEntity(tarifa, dto);
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