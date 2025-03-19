using SGHR.Domain.Entities;

namespace SGHR.Domain.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
