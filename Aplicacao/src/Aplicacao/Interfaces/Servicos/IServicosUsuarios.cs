using Aplicacao.DTO.Request;
using Dominio.Entidades;
using Dominio.Interface.Generico;

namespace Aplicacao.Interfaces.Servicos
{
    public interface IServicosUsuarios : InterfaceGenericos<Usuarios>
    {
        Task<string> Login(UsuariosRequest login);
    }
}