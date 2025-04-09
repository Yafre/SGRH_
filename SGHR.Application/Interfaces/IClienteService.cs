using SGHR.Application.Base;
using SGHR.Application.Dtos.Cliente;
using SGHR.Domain.Base;
using SGHR.Model.Model;

namespace SGHR.Application.Interfaces
{
    public interface IClienteService : IBaseService<ClienteDto, SaveClienteDto, UpdateClienteDto, RemoveClienteDto>
    {
        Task<OperationResult> ActivateAsync(int id);

        Task<ClienteGetModel> GetDetailedByIdAsync(int id);
    }
}
