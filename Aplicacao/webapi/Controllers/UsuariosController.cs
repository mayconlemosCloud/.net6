using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly InterfaceUsuarios _interfaceUsuarios;

        public UsuariosController(InterfaceUsuarios interfaceUsuarios)
        {
            _interfaceUsuarios = interfaceUsuarios;
        }

   
        [HttpPost]
        public async Task<ActionResult<Usuarios>> Adicionar(Usuarios usuario)
        {
           await _interfaceUsuarios.Adicionar(usuario);
           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> Deletar(string id)
        {
            var usuario = await _interfaceUsuarios.BuscarPorId(id);

            if(usuario == null)
            {
                return BadRequest();
            }
            await _interfaceUsuarios.Excluir(usuario);
            return Ok();
        }

    }
}
