using SGHR.Application.Dtos.Recepcion;
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
    public class RecepcionService : IRecepcionService
    {
        private readonly IRecepcionRepository _recepcionRepository;

        public RecepcionService(IRecepcionRepository recepcionRepository)
        {
            _recepcionRepository = recepcionRepository;
        }

        public async Task<IEnumerable<RecepcionDto>> GetAllAsync()
        {
            var recepciones = await _recepcionRepository.GetAllAsync();
            return recepciones.Select(RecepcionMapper.ToDto);
        }

        public async Task<RecepcionDto> GetByIdAsync(int id)
        {
            var recepcion = await _recepcionRepository.GetByIdAsync(id);
            if (recepcion == null)
                throw new KeyNotFoundException("Recepción no encontrada");

            return RecepcionMapper.ToDto(recepcion);
        }

        public async Task<OperationResult> CreateAsync(SaveRecepcionDto dto)
        {
            var recepcion = RecepcionMapper.ToEntity(dto);
            return await _recepcionRepository.AddAsync(recepcion);
        }

        public async Task<OperationResult> UpdateAsync(UpdateRecepcionDto dto)
        {
            var recepcion = await _recepcionRepository.GetByIdAsync(dto.IdRecepcion);
            if (recepcion == null)
                return new OperationResult { Success = false, Message = "Recepción no encontrada" };

            RecepcionMapper.UpdateEntity(recepcion, dto);
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
}