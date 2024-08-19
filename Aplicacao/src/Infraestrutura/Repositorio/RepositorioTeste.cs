using Dominio.Entidades;
using Dominio.Interface.Repositorio;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Generico;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class RepositorioTeste : RepositorioGenerico<Teste>, IRepositorioTeste
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioTeste(DbContextOptions<Contexto> optionsBuilder) : base(optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }
    }
}