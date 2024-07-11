using Dominio.Interfaces;
using Entidades.Entidades;

namespace Dominio.Servicos
{
    public class ServicosUsuarios : InterfaceUsuarios
    {
        private readonly InterfaceUsuarios _interfaceUsuarios;

        public ServicosUsuarios(InterfaceUsuarios interfaceUsuarios)
        {
            _interfaceUsuarios = interfaceUsuarios;
        }
        

        public async Task Adicionar(Usuarios Objeto)
        {
           await _interfaceUsuarios.Adicionar(Objeto);
        }

        public async Task Atualizar(Usuarios Objeto)
        {
          await _interfaceUsuarios.Atualizar(Objeto);
        }

        public async Task<Usuarios> BuscarPorId(string Id)
        {
           return await _interfaceUsuarios.BuscarPorId(Id);
        }

        public async Task Excluir(Usuarios Objeto)
        {
            await _interfaceUsuarios.Excluir(Objeto);
        }

        public async Task<List<Usuarios>> Listar()
        {
            return await _interfaceUsuarios.Listar();
        }
    }
}
