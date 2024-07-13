using Aplicacao.DTO.Request;
using Aplicacao.Interfaces.Servicos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly IServicosTeste _servicoTeste;

        public TesteController(IServicosTeste servicoTeste)
        {
            _servicoTeste = servicoTeste;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] Teste request)
        {
          var resultado = await _servicoTeste.Adicionar(request);
          return Ok(resultado);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(string id) {
           var resultado = await _servicoTeste.Excluir(id);
           return Ok(resultado);
        }


        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var resultado = await _servicoTeste.Listar();
            return Ok(resultado);
        }
    }
}