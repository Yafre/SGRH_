using SGHR.Application.Dtos.Servicio;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ServicioDto>> GetAllAsync()
        {
            var servicios = await _servicioRepository.GetAllAsync();
            return servicios.Select(s => new ServicioDto
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Estado = s.Estado
            });
        }

        public async Task<ServicioDto> GetByIdAsync(int id)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id);
            if (servicio == null)
                throw new KeyNotFoundException("Servicio no encontrado");

            return new ServicioDto
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Estado = servicio.Estado
            };
        }

        public async Task<OperationResult> CreateAsync(SaveServicioDto dto)
        {
            var servicio = new Servicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado
            };
            return await _servicioRepository.AddAsync(servicio);
        }

        public async Task<OperationResult> UpdateAsync(UpdateServicioDto dto)
        {
            var servicio = await _servicioRepository.GetByIdAsync(dto.IdServicio);
            if (servicio == null)
                return new OperationResult { Success = false, Message = "Servicio no encontrado" };

            servicio.Nombre = dto.Nombre;
            servicio.Descripcion = dto.Descripcion;
            servicio.Estado = dto.Estado;
            return await _servicioRepository.UpdateAsync(servicio);
        }

        public async Task<OperationResult> RemoveAsync(RemoveServicioDto dto)
        {
            var servicio = await _servicioRepository.GetByIdAsync(dto.IdServicio);
            if (servicio == null)
                return new OperationResult { Success = false, Message = "Servicio no encontrado" };

            servicio.Estado = dto.Estado;
            return await _servicioRepository.UpdateAsync(servicio);
        }
    }
}
