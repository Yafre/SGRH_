using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Application.Dtos.Servicio;
using SGHR.Domain.Base;
using SGHR.Model.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGHR.Application.Test.Services
{
    public class ServicioServiceTest
    {
        private readonly Mock<IServicioRepository> _repositoryMock;
        private readonly ServicioService _service;

        public ServicioServiceTest()
        {
            _repositoryMock = new Mock<IServicioRepository>();
            _service = new ServicioService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<ServicioGetModel> { new ServicioGetModel { IdServicio = 1, Nombre = "Test" } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveServicioDto { Nombre = "Test Service", Descripcion = "Test Desc" };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<SGHR.Domain.Entities.Servicio>()))
                .ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
