using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using SGHR.Domain.Entities;
using System.Threading.Tasks;

namespace SGHR.Persistence.Test.Repositories
{
    public class ServicioRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly ServicioRepository _repository;

        public ServicioRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Servicio")
                .Options;

            _context = new SGHRContext(options);
            var mockLogger = new Mock<ILogger<ServicioRepository>>();

            _repository = new ServicioRepository(_context, mockLogger.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Servicio { Nombre = "Spa", Descripcion = "Relax" };
            var result = await _repository.AddAsync(entity);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Servicio>().Add(new Servicio { Nombre = "Spa", Descripcion = "Relax" });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();
            Assert.NotNull(result);
        }
    }
}
