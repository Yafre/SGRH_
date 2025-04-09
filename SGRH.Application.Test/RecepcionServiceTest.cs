using Moq;
using SGHR.Application.Dtos.Recepcion;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Application.Test
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
        public async Task GetAllAsync_ShouldReturnAllRecepciones()
        {
            var recepciones = new List<Recepcion>
            {
                new() { IdRecepcion = 1, IdCliente = 2, IdHabitacion = 3, TotalPagado = 150 }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(recepciones);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(150, result.First().TotalPagado);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnRecepcion()
        {
            var recepcion = new Recepcion
            {
                IdRecepcion = 1,
                IdCliente = 2,
                IdHabitacion = 3,
                TotalPagado = 200
            };

            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(recepcion);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(200, result.TotalPagado);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Recepcion)null!);

            var result = await _service.UpdateAsync(new UpdateRecepcionDto { IdRecepcion = 99 });

            Assert.False(result.Success);
            Assert.Equal("Recepción no encontrada", result.Message);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Recepcion)null!);

            var result = await _service.RemoveAsync(new RemoveRecepcionDto { IdRecepcion = 99 });

            Assert.False(result.Success);
            Assert.Equal("Recepción no encontrada", result.Message);
        }
    }
}
