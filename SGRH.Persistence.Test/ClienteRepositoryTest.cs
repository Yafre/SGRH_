using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SGHR.Domain.Entities;
using SGHR.Persistence.Context;
using SGHR.Persistence.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Persistence.Test
{
    public class ClienteRepositoryTest
    {
        [Fact]
        public async Task AddAsync_ShouldAddCliente()
        {
            var options = new DbContextOptionsBuilder<SGHRContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new SGHRContext(options);
            var loggerMock = new Mock<ILogger<ClienteRepository>>();
            var repository = new ClienteRepository(context, loggerMock.Object);

            var cliente = new Cliente { NombreCompleto = "Juan Pérez", Correo = "juan@mail.com", Estado = true };

            var result = await repository.AddAsync(cliente);

            Assert.True(result.Success);
            var allClientes = await repository.GetAllAsync();
            Assert.Single(allClientes);
        }
    }
}
