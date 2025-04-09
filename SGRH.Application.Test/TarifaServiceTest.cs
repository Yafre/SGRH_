using Moq;
using SGHR.Application.Dtos.Tarifa;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Application.Test
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
        public async Task GetAllAsync_ShouldReturnAllTarifas()
        {
            var tarifas = new List<Tarifa>
            {
                new() { IdTarifa = 1, IdHabitacion = 1, PrecioPorNoche = 150 }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(tarifas);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(150, result.First().PrecioPorNoche);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTarifa()
        {
            var tarifa = new Tarifa { IdTarifa = 1, IdHabitacion = 1, PrecioPorNoche = 200 };

            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(tarifa);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(200, result.PrecioPorNoche);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Tarifa?)null!);

            var result = await _service.UpdateAsync(new UpdateTarifaDto { IdTarifa = 99 });

            Assert.False(result.Success);
            Assert.Equal("Tarifa no encontrada", result.Message);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnSuccess_WhenFound()
        {
            var tarifa = new Tarifa { IdTarifa = 1, Estado = true };
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(tarifa);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Tarifa>())).ReturnsAsync(new SGHR.Domain.Base.OperationResult { Success = true });

            var result = await _service.RemoveAsync(new RemoveTarifaDto { IdTarifa = 1 });

            Assert.True(result.Success);
        }
    }
}
