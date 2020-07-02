using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.RestWithAspNetUdemy.Servicos.Implementacao;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            
            if (pessoa == null)
                return BadRequest();

            return new ObjectResult(_pessoaServico.Criar(pessoa));

        }

        [HttpPut]
        public ActionResult Put([FromBody] Pessoa pessoa)
        {

            if (pessoa == null)
                return BadRequest();

            return new ObjectResult(_pessoaServico.Atualizar(pessoa));

        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
             _pessoaServico.Excluir(Id);
            return NoContent();
        }

    }
}
