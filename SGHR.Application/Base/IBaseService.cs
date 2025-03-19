using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGHR.Domain.Base;

namespace SGHR.Application.Base
{
    public interface IBaseService<TDto, TSaveDto, TUpdateDto, TRemoveDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<OperationResult> CreateAsync(TSaveDto dto);
        Task<OperationResult> UpdateAsync(TUpdateDto dto);
        Task<OperationResult> RemoveAsync(TRemoveDto dto);
    }
}
