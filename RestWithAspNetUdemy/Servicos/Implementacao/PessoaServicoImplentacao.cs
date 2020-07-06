using RestWithAspNetUdemy.Data.Converters;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Implementacao;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Servicos.Implementacao
{
    public class PessoaServicoImplentacao : IPessoaServico
    {
        //private volatile int count;

        private IPessoaRepository _repository;
        private readonly PessoaConverter _converter;
        public PessoaServicoImplentacao(IPessoaRepository repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();

        }

        public PessoaVO Atualizar(PessoaVO pessoa)
        {
           
            var pessoaEntidade = _converter.Parse(pessoa);
            pessoaEntidade = _repository.Atualizar(pessoaEntidade);
            return _converter.Parse(pessoaEntidade);


        }


        public PessoaVO Criar(PessoaVO pessoa)
        {
            var pessoaEntidade = _converter.Parse(pessoa);
            pessoaEntidade = _repository.Criar(pessoaEntidade);
            return _converter.Parse(pessoaEntidade);
        }

        public void Excluir(long Id)
        {
             _repository.Excluir(Id); 
   
        }

        public PessoaVO LocalizarPorID(long Id)
        {
            return _converter.Parse(_repository.LocalizarPorID(Id));

        }

        public List<PessoaVO> LocalizarTodas()
        {
            return _converter.ParseList(_repository.LocalizarTodas());

        }


    }
}
