using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Servicos.Implementacao;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]/v{version:apiVersion}/")]
    public class LivroController : ControllerBase
    {
        private ILivroServico _livroServico;

        public LivroController(ILivroServico livroServico)
        {
            _livroServico = livroServico;
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livroServico.LocalizarTodas());

        }

        [HttpGet("{Id}")]
        public IActionResult Get(long Id)
        {
            var livroServico = _livroServico.LocalizarPorID(Id);
            if (livroServico == null)
                return NotFound();

            return Ok(livroServico);


        }

        [HttpPost]
        public ActionResult Post([FromBody] LivroVO livro)
        {

            if (livro == null)
                return BadRequest();

            return new ObjectResult(_livroServico.Criar(livro));
  
        }

        [HttpPut]
        public ActionResult Put([FromBody] LivroVO livro)
        {

            if (livro == null)
                return BadRequest();

            var livroAtualizada = _livroServico.Atualizar(livro);

            if (livroAtualizada == null)
                return BadRequest();

            return new ObjectResult(livroAtualizada);

        }


        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            _livroServico.Excluir(Id);
            return NoContent();

        }
    }
}
