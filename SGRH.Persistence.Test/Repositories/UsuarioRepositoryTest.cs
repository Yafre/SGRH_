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
    public class UsuarioRepositoryTest
    {
        private readonly SGHRContext _context;
        private readonly UsuarioRepository _repository;

        public UsuarioRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(databaseName: "SGHR_TestDB_Usuario")
                .Options;

            _context = new SGHRContext(options);
            var mockLogger = new Mock<ILogger<UsuarioRepository>>();
            var mockConfig = new Mock<IConfiguration>();

            _repository = new UsuarioRepository(_context, mockLogger.Object, mockConfig.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            var entity = new Usuario { NombreCompleto = "Test User", Correo = "test@correo.com" };
            var result = await _repository.AddAsync(entity);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _context.Set<Usuario>().Add(new Usuario { NombreCompleto = "Test User", Correo = "test@correo.com" });
            await _context.SaveChangesAsync();

            var result = await _repository.GetAllAsync();
            Assert.NotNull(result);
        }
    }
}
