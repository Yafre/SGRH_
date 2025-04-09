using Moq;
using SGHR.Application.Dtos.Usuario;
using SGHR.Application.Interfaces;
using SGHR.Application.Services;
using SGHR.Domain.Entities;
using SGHR.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SGRH.Application.Test
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
        public async Task GetAllAsync_ShouldReturnAllUsuarios()
        {
            var usuarios = new List<Usuario>
            {
                new() { IdUsuario = 1, NombreCompleto = "María Perez", Correo = "maria@test.com", Estado = true }
            };

            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(usuarios);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("maria@test.com", result.First().Correo);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnUsuario()
        {
            var usuario = new Usuario { IdUsuario = 1, NombreCompleto = "Carlos Ruiz", Correo = "carlos@test.com", Estado = true };

            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Carlos Ruiz", result.NombreCompleto);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnFailure_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Usuario?)null!);

            var result = await _service.UpdateAsync(new UpdateUsuarioDto { IdUsuario = 99 });

            Assert.False(result.Success);
            Assert.Equal("Usuario no encontrado", result.Message);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnSuccess_WhenFound()
        {
            var usuario = new Usuario { IdUsuario = 1, Estado = true };
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);
            _repositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Usuario>())).ReturnsAsync(new SGHR.Domain.Base.OperationResult { Success = true });

            var result = await _service.RemoveAsync(new RemoveUsuarioDto { IdUsuario = 1 });

            Assert.True(result.Success);
        }
    }
}
