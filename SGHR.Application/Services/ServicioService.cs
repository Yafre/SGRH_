﻿using SGHR.Application.Dtos.Servicio;
using SGHR.Application.Interfaces;
using SGHR.Domain.Base;
using SGHR.Domain.Entities.Servicios;
using SGHR.Model.Model;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public class ServicioService(IServicioRepository servicioRepository) : IServicioService
    {
        private readonly IServicioRepository _servicioRepository = servicioRepository;

        public async Task<IEnumerable<ServicioDto>> GetAllAsync() =>
            (await _servicioRepository.GetAllAsync()).Select(s => new ServicioDto
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Descripcion = s.Descripcion,
                Estado = s.Estado
            });

        public async Task<ServicioDto> GetByIdAsync(int id)
        {
            var servicio = await _servicioRepository.GetByIdAsync(id)
                           ?? throw new KeyNotFoundException("Servicio no encontrado");

            return new ServicioDto
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                Estado = servicio.Estado
            };
        }

        public async Task<OperationResult> CreateAsync(SaveServicioDto dto) =>
            await _servicioRepository.AddAsync(new Servicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado
            });

        public async Task<OperationResult> UpdateAsync(UpdateServicioDto dto)
        {
            if (await _servicioRepository.ExistsAsync(dto.IdServicio) is false)
                return new OperationResult { Success = false, Message = "Servicio no encontrado" };

            return await _servicioRepository.UpdateAsync(new Servicio
            {
                IdServicio = dto.IdServicio,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Estado = dto.Estado
            });
        }

        public async Task<OperationResult> RemoveAsync(RemoveServicioDto dto)
        {
            var servicio = await _servicioRepository.FindEntityByIdAsync(dto.IdServicio);

            if (servicio == null)
                return new OperationResult { Success = false, Message = "Servicio no encontrado" };

            servicio.Estado = false;

            return await _servicioRepository.UpdateAsync(servicio);
        }
    }
}
