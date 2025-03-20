using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Domain.Base;
using System.Threading.Tasks;
using System.Collections.Generic;
using SGHR.Domain.Entities.Habitaciones;

namespace SGHR.Application.Test.Services
{
    public class HabitacionServiceTest
    {
        private readonly Mock<IHabitacionRepository> _repositoryMock;
        private readonly HabitacionService _service;

        public HabitacionServiceTest()
        {
            _repositoryMock = new Mock<IHabitacionRepository>();
            _service = new HabitacionService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Habitacion> { new Habitacion { } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveHabitacionDto { };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Habitacion>())).ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
