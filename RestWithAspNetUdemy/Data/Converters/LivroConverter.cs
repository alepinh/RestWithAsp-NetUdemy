using RestWithAspNetUdemy.Data.Converter;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Data.Converters
{
    public class LivroConverter : IParser<LivroVO, Livro>, IParser<Livro, LivroVO>
    {
        public Livro Parse(LivroVO origem)
        {
            if (origem == null) return new Livro();
            return new Livro
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Autor = origem.Autor,
                Preco = origem.Preco,
                DataLancamento = origem.DataLancamento


            };
        }

        public List<Livro> ParseList(List<LivroVO> origem)
        {
            if (origem == null) return new List<Livro>();
            return origem.Select(p => Parse(p)).ToList();
        }

        public LivroVO Parse(Livro origem)
        {
            if (origem == null) return new LivroVO();
            return new LivroVO
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Autor = origem.Autor,
                Preco = origem.Preco,
                DataLancamento = origem.DataLancamento


            };
        }

        public List<LivroVO> ParseList(List<Livro> origem)
        {
            if (origem == null) return new List<LivroVO>();
            return origem.Select(p => Parse(p)).ToList();
        }
    }
}
