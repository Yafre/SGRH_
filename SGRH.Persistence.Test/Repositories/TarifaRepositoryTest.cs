using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Moq;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using SGHR.Domain.Entities;
using System.Threading.Tasks;

namespace SGHR.Persistence.Test.Repositories
{
    public class TarifaRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly TarifaRepository _repository;

        public TarifaRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Tarifa")
                .Options;

            _context = new SGHRContext(options);
            var mockLogger = new Mock<ILogger<TarifaRepository>>();
            var mockConfig = new Mock<IConfiguration>();

            _repository = new TarifaRepository(_context, mockLogger.Object, mockConfig.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Tarifa { IdHabitacion = 1, PrecioPorNoche = 150 };
            var result = await _repository.AddAsync(entity);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Tarifa>().Add(new Tarifa { IdHabitacion = 1, PrecioPorNoche = 150 });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();
            Assert.NotNull(result);
        }
    }
}
