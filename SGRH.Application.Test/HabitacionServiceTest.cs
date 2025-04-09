using Moq;
using SGHR.Application.Dtos.Habitacion;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Domain.Entities.Habitaciones;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Application.Test
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
        public async Task GetAllAsync_ShouldReturnAllHabitaciones()
        {
            var habitaciones = new List<Habitacion>
            {
                new() { IdHabitacion = 1, Numero = "101", Detalle = "Habitación doble", Precio = 100, Estado = true }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(habitaciones);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("101", result.First().Numero);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnHabitacion()
        {
            var habitacion = new Habitacion
            {
                IdHabitacion = 1,
                Numero = "101",
                Detalle = "Habitación doble",
                Precio = 100,
                Estado = true
            };

            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(habitacion);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("101", result.Numero);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Habitacion)null!);

            var result = await _service.UpdateAsync(new UpdateHabitacionDto { IdHabitacion = 99 });

            Assert.False(result.Success);
            Assert.Equal("Habitación no encontrada", result.Message);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Habitacion)null!);

            var result = await _service.RemoveAsync(new RemoveHabitacionDto { IdHabitacion = 99 });

            Assert.False(result.Success);
            Assert.Equal("Habitación no encontrada", result.Message);
        }
    }
}
