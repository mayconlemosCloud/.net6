using Aplicacao.Interfaces.Servicos;
using Dominio.Entidades;
using Dominio.Interface.Generico;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class ServicosUsuarios : IServicosUsuarios
    {
        private readonly UserManager<Usuarios> _userManager;

        public ServicosUsuarios(UserManager<Usuarios> userManager)
        {
            _userManager = userManager;
        }

        public Task<Usuarios> Adicionar(Usuarios Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> Atualizar(Usuarios Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> BuscarPorId(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuarios> Excluir(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Usuarios>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
