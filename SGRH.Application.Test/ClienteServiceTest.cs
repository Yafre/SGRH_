using Moq;
using SGHR.Application.Dtos.Cliente;
using SGHR.Application.Services;
using SGHR.Domain.Base;
using SGHR.Domain.Entities;
using SGHR.Model.Model;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Application.Test
{
    public class ClienteServiceTest
    {
        private readonly Mock<IClienteRepository> _repositoryMock;
        private readonly ClienteService _service;

        public ClienteServiceTest()
        {
            _repositoryMock = new Mock<IClienteRepository>();
            _service = new ClienteService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllClients()
        {
            var clientes = new List<ClienteGetModel>
            {
                new ClienteGetModel
                {
                    IdCliente = 1,
                    NombreCompleto = "Juan Pérez",
                    Correo = "juan@mail.com",
                    Estado = true
                }
            };

            _repositoryMock.Setup(r => r.GetAllClientesAsync()).ReturnsAsync(clientes);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Juan Pérez", result.First().NombreCompleto);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnClienteDto()
        {
            var cliente = new ClienteGetModel
            {
                IdCliente = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan@mail.com",
                Estado = true
            };

            _repositoryMock.Setup(r => r.GetClienteViewByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new OperationResult { Success = true, Data = cliente });

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Juan Pérez", result.NombreCompleto);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.FindEntityByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Cliente?)null);

            var result = await _service.UpdateAsync(new UpdateClienteDto { IdCliente = 99 });

            Assert.False(result.Success);
            Assert.Equal("Cliente no encontrado.", result.Message);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFailure_WhenDeleteFails()
        {
            _repositoryMock.Setup(r => r.DeleteClienteAsync(It.IsAny<int>()))
                .ReturnsAsync(new OperationResult { Success = false, Message = "Cliente no encontrado." });

            var result = await _service.RemoveAsync(new RemoveClienteDto { IdCliente = 99 });

            Assert.False(result.Success);
            Assert.Equal("Cliente no encontrado.", result.Message);
        }
    }
}
