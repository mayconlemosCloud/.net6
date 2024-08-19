using Aplicacao.Interfaces.Servicos;
using Dominio.Entidades;
using Dominio.Interface.Repositorio;

namespace Aplicacao.Servicos
{
    public class ServicosTeste : IServicosTeste
    {
        private readonly IRepositorioTeste _repositorioTeste;

        public ServicosTeste(IRepositorioTeste repositorioTeste)
        {
            _repositorioTeste = repositorioTeste;
        }

        public async Task<Teste> Adicionar(Teste Objeto)
        {
            return await _repositorioTeste.Adicionar(Objeto);
        }

        public Task<Teste> Atualizar(Teste Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Teste> BuscarPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Teste> Excluir(string Id)
        {
            var resultado = await _repositorioTeste.BuscarPorId(Id);

            if (resultado.Id == Id)
            {
                return await _repositorioTeste.Excluir(resultado);
            }

            return new Teste();
        }

        public async Task<List<Teste>> Listar()
        {
            return await _repositorioTeste.Listar();
        }
    }
}