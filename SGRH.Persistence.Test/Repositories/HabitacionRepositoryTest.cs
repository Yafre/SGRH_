using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Moq;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using SGHR.Domain.Entities.Habitaciones;
using System.Threading.Tasks;

namespace SGHR.Persistence.Test.Repositories
{
    public class HabitacionRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly HabitacionRepository _repository;

        public HabitacionRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Habitacion")
                .Options;

            _context = new SGHRContext(options);

            var mockLogger = new Mock<ILogger<HabitacionRepository>>();
            var mockConfig = new Mock<IConfiguration>();

            _repository = new HabitacionRepository(_context, mockLogger.Object, mockConfig.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Habitacion { Numero = "101", Detalle = "Test", Precio = 100 };
            var result = await _repository.AddAsync(entity);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Habitacion>().Add(new Habitacion { Numero = "101", Detalle = "Test", Precio = 100 });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();
            Assert.NotNull(result);
        }
    }
}
