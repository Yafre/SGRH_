using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGHR.Application.Services
{
    public interface IBaseService<TModel>
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel?> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<bool> UpdateAsync(int id, TModel model);
        Task<bool> DeleteAsync(int id);
    }
}
