using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SGHR.Domain.Entities;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Persistence.Test
{
    public class TarifaRepositoryTest
    {
        [Fact]
        public async Task AddAsync_ShouldAddTarifa()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new SGHRContext(options);
            var loggerMock = new Mock<ILogger<TarifaRepository>>();
            var configMock = new Mock<IConfiguration>();
            var repository = new TarifaRepository(context, loggerMock.Object, configMock.Object);

            var tarifa = new Tarifa { IdHabitacion = 1, PrecioPorNoche = 150 };

            var result = await repository.AddAsync(tarifa);

            Assert.True(result.Success);
            var allTarifas = await repository.GetAllAsync();
            Assert.Single(allTarifas);
        }
    }
}
