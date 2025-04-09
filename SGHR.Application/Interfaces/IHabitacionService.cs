using SGHR.Application.Dtos.Habitacion;
using SGHR.Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGHR.Application.Interfaces
{
    public interface IHabitacionService
    {
        Task<IEnumerable<HabitacionDto>> GetAllAsync();
        Task<HabitacionDto> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(SaveHabitacionDto dto);
        Task<OperationResult> UpdateAsync(UpdateHabitacionDto dto);
        Task<OperationResult> RemoveAsync(RemoveHabitacionDto dto);
        Task<OperationResult> ActivateAsync(int id); 
    }
}
