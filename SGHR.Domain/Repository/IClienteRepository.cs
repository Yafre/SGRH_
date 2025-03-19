using SGHR.Domain.Entities;

namespace SGHR.Domain.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente?> GetByEmailAsync(string email);
    }
}
