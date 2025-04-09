using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SGHR.Domain.Entities;
using Microsoft.Extensions.Configuration;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Persistence.Test
{
    public class RecepcionRepositoryTest
    {
        [Fact]
        public async Task AddAsync_ShouldAddRecepcion()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new SGHRContext(options);
            var loggerMock = new Mock<ILogger<RecepcionRepository>>();
            var configMock = new Mock<IConfiguration>();
            var repository = new RecepcionRepository(context, loggerMock.Object, configMock.Object);

            var recepcion = new Recepcion { IdCliente = 1, IdHabitacion = 1, TotalPagado = 500 };

            var result = await repository.AddAsync(recepcion);

            Assert.True(result.Success);
            var allRecepciones = await repository.GetAllAsync();
            Assert.Single(allRecepciones);
        }
    }
}
