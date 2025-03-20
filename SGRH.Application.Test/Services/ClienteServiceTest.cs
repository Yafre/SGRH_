using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Cliente;
using SGHR.Domain.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGHR.Application.Test.Services
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
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Cliente> { new Cliente { } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveClienteDto { };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Cliente>())).ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
