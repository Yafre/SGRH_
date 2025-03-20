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
    public class ClienteRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly ClienteRepository _repository;

        public ClienteRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Cliente")
                .Options;

            _context = new SGHRContext(options);

            // Creamos un mock de ILogger
            var mockLogger = new Mock<ILogger<ClienteRepository>>();
            _repository = new ClienteRepository(_context, mockLogger.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Cliente { NombreCompleto = "Test", Correo = "test@mail.com" };
            var result = await _repository.AddAsync(entity);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Cliente>().Add(new Cliente { NombreCompleto = "Test", Correo = "test@mail.com" });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();

            Assert.NotNull(result);
        }
    }
}
