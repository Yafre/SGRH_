using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Recepcion;
using SGHR.Domain.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGHR.Application.Test.Services
{
    public class RecepcionServiceTest
    {
        private readonly Mock<IRecepcionRepository> _repositoryMock;
        private readonly RecepcionService _service;

        public RecepcionServiceTest()
        {
            _repositoryMock = new Mock<IRecepcionRepository>();
            _service = new RecepcionService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Recepcion> { new Recepcion { } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveRecepcionDto { };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Recepcion>())).ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
