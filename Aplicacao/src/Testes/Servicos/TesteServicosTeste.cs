using Aplicacao.Interfaces.Servicos;
using Aplicacao.Servicos;
using Dominio.Entidades;
using Dominio.Interface.Repositorio;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Servicos
{
    public class ServicosTesteTests
    {
        private readonly ServicosTeste _servicosTeste;
        private readonly Mock<IRepositorioTeste> _repositorioTesteMock;

        public ServicosTesteTests()
        {
            _repositorioTesteMock = new Mock<IRepositorioTeste>();
            _servicosTeste = new ServicosTeste(_repositorioTesteMock.Object);
        }

        [Fact]
        public async Task Adicionar_ShouldReturnAddedTeste()
        {
            // Arrange
            var teste = new Teste { Id = "1", Name = "Teste1" };
            _repositorioTesteMock.Setup(repo => repo.Adicionar(teste)).ReturnsAsync(teste);

            // Act
            var resultado = await _servicosTeste.Adicionar(teste);

            // Assert
            resultado.Should().BeEquivalentTo(teste);
            _repositorioTesteMock.Verify(repo => repo.Adicionar(teste), Times.Once);
        }

        [Fact]
        public async Task Excluir_ShouldReturnDeletedTeste_WhenIdMatches()
        {
            // Arrange
            var teste = new Teste { Id = "1", Name = "Teste1" };
            _repositorioTesteMock.Setup(repo => repo.BuscarPorId("1")).ReturnsAsync(teste);
            _repositorioTesteMock.Setup(repo => repo.Excluir(teste)).ReturnsAsync(teste);

            // Act
            var resultado = await _servicosTeste.Excluir("1");

            // Assert
            resultado.Should().BeEquivalentTo(teste);
            _repositorioTesteMock.Verify(repo => repo.BuscarPorId("1"), Times.Once);
            _repositorioTesteMock.Verify(repo => repo.Excluir(teste), Times.Once);
        }

        [Fact]
        public async Task Excluir_ShouldReturnEmptyTeste_WhenIdDoesNotMatch()
        {
            // Arrange
            var teste = new Teste { Id = "1", Name = "Teste1" };
            _repositorioTesteMock.Setup(repo => repo.BuscarPorId("2")).ReturnsAsync(teste);

            // Act
            var resultado = await _servicosTeste.Excluir("2");

            // Assert
            resultado.Should().NotBeEquivalentTo(teste);
            resultado.Should().BeEquivalentTo(new Teste());
            _repositorioTesteMock.Verify(repo => repo.BuscarPorId("2"), Times.Once);
            _repositorioTesteMock.Verify(repo => repo.Excluir(It.IsAny<Teste>()), Times.Never);
        }

        [Fact]
        public async Task Listar_ShouldReturnListOfTestes()
        {
            // Arrange
            var listaTeste = new List<Teste>
            {
                new Teste { Id = "1", Name = "Teste1" },
                new Teste { Id = "2", Name = "Teste2" }
            };
            _repositorioTesteMock.Setup(repo => repo.Listar()).ReturnsAsync(listaTeste);

            // Act
            var resultado = await _servicosTeste.Listar();

            // Assert
            resultado.Should().BeEquivalentTo(listaTeste);
            _repositorioTesteMock.Verify(repo => repo.Listar(), Times.Once);
        }
    }
}
