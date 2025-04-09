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
    public class UsuarioRepositoryTest
    {
        [Fact]
        public async Task AddAsync_ShouldAddUsuario()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new SGHRContext(options);
            var loggerMock = new Mock<ILogger<UsuarioRepository>>();
            var configMock = new Mock<IConfiguration>();
            var repository = new UsuarioRepository(context, loggerMock.Object, configMock.Object);

            var usuario = new Usuario { NombreCompleto = "Pedro Martinez", Correo = "pedro@mail.com" };

            var result = await repository.AddAsync(usuario);

            Assert.True(result.Success);
            var allUsuarios = await repository.GetAllAsync();
            Assert.Single(allUsuarios);
        }
    }
}
