using Aplicacao.DTO.Request;
using Aplicacao.Interfaces.Servicos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IServicosUsuarios _servicosUsuarios;

        public UsuariosController(IServicosUsuarios servicosUsuarios)
        {
            _servicosUsuarios = servicosUsuarios;
        }

        [Produces("application/json")]
        [HttpPost("/api/Adiciona")]
        public async Task<ActionResult> Adicionar([FromBody] UsuariosRequest usuariosRequest)
        {
            var user = new Usuarios()
            {
                Email = usuariosRequest.Email,
                PasswordHash = usuariosRequest.PasswordHash,
            };

            await _servicosUsuarios.Adicionar(user);
            return Ok("Criado");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/Login")]
        public async Task<IActionResult> Login([FromBody] UsuariosRequest login)
        {
            var resultado = await _servicosUsuarios.Login(login);
            return Ok(resultado);
        }
    }
}