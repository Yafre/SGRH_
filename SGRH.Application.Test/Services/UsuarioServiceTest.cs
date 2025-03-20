using Moq;
using Xunit;
using SGHR.Application.Services;
using SGHR.Persistence.Interfaces;
using SGHR.Domain.Entities;
using SGHR.Application.Dtos.Usuario;
using SGHR.Domain.Base;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGHR.Application.Test.Services
{
    public class UsuarioServiceTest
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioService _service;

        public UsuarioServiceTest()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _service = new UsuarioService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEntities()
        {
            _repositoryMock.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Usuario> { new Usuario { } });

            var result = await _service.GetAllAsync();

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess()
        {
            var dto = new SaveUsuarioDto { };
            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<Usuario>())).ReturnsAsync(new OperationResult { Success = true });

            var result = await _service.CreateAsync(dto);

            Assert.True(result.Success);
        }
    }
}
