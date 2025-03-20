using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Tarifa;
using SGHR.Domain.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGHR.Application.Test.Services
{
    public class TarifaServiceTest
    {
        private readonly Mock<ITarifaRepository> _repositoryMock;
        private readonly TarifaService _service;

        public TarifaServiceTest()
        {
            _repositoryMock = new Mock<ITarifaRepository>();
            _service = new TarifaService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Tarifa> { new Tarifa { } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveTarifaDto { };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Tarifa>())).ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
