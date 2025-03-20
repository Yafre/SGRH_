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
    public class RecepcionRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly RecepcionRepository _repository;

        public RecepcionRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Recepcion")
                .Options;

            _context = new SGHRContext(options);

            var mockLogger = new Mock<ILogger<RecepcionRepository>>();
            var mockConfig = new Mock<IConfiguration>();

            _repository = new RecepcionRepository(_context, mockLogger.Object, mockConfig.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Recepcion { IdCliente = 1, IdHabitacion = 1, PrecioInicial = 50 };
            var result = await _repository.AddAsync(entity);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Recepcion>().Add(new Recepcion { IdCliente = 1, IdHabitacion = 1, PrecioInicial = 50 });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();
            Assert.NotNull(result);
        }
    }
}
