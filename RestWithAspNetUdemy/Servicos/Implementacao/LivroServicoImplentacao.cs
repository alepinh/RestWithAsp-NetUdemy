using RestWithAspNetUdemy.Data.Converters;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository.Implementacao;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Servicos.Implementacao
{
    public class LivroServicoImplentacao : ILivroServico
    {
        //private volatile int count;

        private IRepository<Livro> _repository;
        private readonly LivroConverter _converter;

        public LivroServicoImplentacao(IRepository<Livro> repository)
        {
            _repository = repository;
            _converter = new LivroConverter();
        }

        public LivroVO Atualizar(LivroVO livro)
        {
           
            var livroEntidade = _converter.Parse(livro);
            livroEntidade = _repository.Atualizar(livroEntidade);
            return _converter.Parse(livroEntidade);




        }


        public LivroVO Criar(LivroVO livro)
        {
            var livroEntidade = _converter.Parse(livro);
            livroEntidade = _repository.Criar(livroEntidade);
            return _converter.Parse(livroEntidade);
        }

        public void Excluir(long Id)
        {
             _repository.Excluir(Id); 
   
        }

        public LivroVO LocalizarPorID(long Id)
        {
            return _converter.Parse(_repository.LocalizarPorID(Id));

        }

        public List<LivroVO> LocalizarTodas()
        {
            return _converter.ParseList(_repository.LocalizarTodas());

        }


    }
}
