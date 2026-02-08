using Clientes.Api.DTOs;
using Clientes.Api.Models;
using Clientes.Api.Repositories;
using Clientes.Api.Services;
using Moq;
using Xunit;

namespace Clientes.Api.Tests
{
    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteService _clienteService;
        public ClienteServiceTests()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_clienteRepositoryMock.Object);
        }
        [Fact]
        public async Task CreateAsync_DeveCriarClienteComSucesso()
        {
            // Arrange
            var clienteDto = new ClienteCreateDto
            {
                Nome = "Teste",
                Email = "teste@email.com",
                Documento = "123"
            };
            // Act
            var result = await _clienteService.CreateAsync(clienteDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clienteDto.Nome, result.Nome);
            Assert.Equal(clienteDto.Email, result.Email);
        }
        [Fact]
        public async Task UpdateAsync_DeveRetornarFalse_QuandoClienteNaoExiste()
        {
            // Arrange
            _clienteRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Cliente?)null);
            var clienteDto = new ClienteUpdateDto
            {
                Nome = "Teste",
                Email = "teste@email.com",
                Documento = "123"
            };
            // Act
            var result = await _clienteService.UpdateAsync(Guid.NewGuid(), clienteDto);

            // Assert
            Assert.False(result);
        }
    }
}   