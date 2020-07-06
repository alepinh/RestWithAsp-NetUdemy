using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspNetUdemy.Data.Converter;

namespace RestWithAspNetUdemy.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origem)
        {
            if (origem == null) return new Pessoa();
            return new Pessoa
            {
                Id = origem.Id,
                Nome = origem.Nome,
                sobreNome = origem.sobreNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero


            };
        }

        public List<Pessoa> ParseList(List<PessoaVO> origem)
        {
            if (origem == null) return new List<Pessoa>();
            return origem.Select(p => Parse(p)).ToList();
        }

        public PessoaVO Parse(Pessoa origem)
        {
            if (origem == null) return new PessoaVO();
            return new PessoaVO
            {
                Id = origem.Id,
                Nome = origem.Nome,
                sobreNome = origem.sobreNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero


            };
        }

        public List<PessoaVO> ParseList(List<Pessoa> origem)
        {
            if (origem == null) return new List<PessoaVO>();
            return origem.Select(p => Parse(p)).ToList();
        }
    }
}
