using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Implementacao
{
    public class PessoaRepositoryImplentacao : IPessoaRepository
    {
        //private volatile int count;

        private MySQLContexto _contexto;

        public PessoaRepositoryImplentacao(MySQLContexto contexto)
        {
            _contexto = contexto;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            if(!Exist(pessoa.Id)) return null;

            var result = _contexto.Pessoas.SingleOrDefault(p => p.Id.Equals(pessoa.Id));

            try
            {
                _contexto.Entry(result).CurrentValues.SetValues(pessoa);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return pessoa;

        }

        public bool Exist(long? Id)
        {
            return _contexto.Pessoas.Any(p => p.Id.Equals(Id));
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            try
            {
                _contexto.Add(pessoa);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return pessoa;
        }

        public void Excluir(long Id)
        {

            var result = _contexto.Pessoas.SingleOrDefault(p => p.Id.Equals(Id));
            try
            {
                if (result != null) _contexto.Pessoas.Remove(result);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Pessoa LocalizarPorID(long Id)
        {
            return _contexto.Pessoas.SingleOrDefault(p => p.Id.Equals(Id));

        }

        public List<Pessoa> LocalizarTodas()
        {
            return _contexto.Pessoas.ToList();

        }


    }
}
