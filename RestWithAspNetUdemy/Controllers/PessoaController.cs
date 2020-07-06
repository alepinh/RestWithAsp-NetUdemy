using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Servicos.Implementacao;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}/")]

    public class PessoaController : ControllerBase
    {
        private IPessoaServico _pessoaServico;

        public PessoaController(IPessoaServico pessoaServico)
        {
            _pessoaServico = pessoaServico;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaServico.LocalizarTodas());
   
        }

        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var pessoaServico = _pessoaServico.LocalizarPorID(Id);
            if (pessoaServico == null)
                return NotFound();

            return Ok(pessoaServico);

        }

        [HttpPost]
        public ActionResult Post([FromBody] PessoaVO pessoa)
        {
            
            if (pessoa == null)
                return BadRequest();

            return new ObjectResult(_pessoaServico.Criar(pessoa));

        }

        [HttpPut]
        public ActionResult Put([FromBody] PessoaVO pessoa)
        {

            if (pessoa == null)
                return BadRequest();

            var pessoaAtualizada = _pessoaServico.Atualizar(pessoa);
            
            if (pessoaAtualizada == null) 
                return BadRequest();
            
            return new ObjectResult(pessoaAtualizada);
        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
             _pessoaServico.Excluir(Id);
            return NoContent();
        }

    }
}
