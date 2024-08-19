using Aplicacao.Interfaces.Servicos;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [Authorize]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] Teste request)
        {
            try
            {
                var resultado = await _servicoTeste.Adicionar(request);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                // Log error (ex) here as needed
                return StatusCode((int)HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao adicionar o teste." });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(string id)
        {
            try
            {
                var resultado = await _servicoTeste.Excluir(id);
                return Ok(resultado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                // Log error (ex) here as needed
                return StatusCode((int)HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao excluir o teste." });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var resultado = await _servicoTeste.Listar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // Log error (ex) here as needed
                return StatusCode((int)HttpStatusCode.InternalServerError, new { mensagem = "Ocorreu um erro ao listar os testes." });
            }
        }
    }
}