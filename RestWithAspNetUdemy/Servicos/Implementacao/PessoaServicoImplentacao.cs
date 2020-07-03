using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Contexto;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.RestWithAspNetUdemy.Servicos.Implementacao
{
    public class PessoaServicoImplentacao : IPessoaServico
    {
        //private volatile int count;

        private MySQLContexto _contexto;

        public PessoaServicoImplentacao(MySQLContexto contexto)
        {
            _contexto = contexto;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            if(!Exist(pessoa.id)) return new Pessoa();

            var result = _contexto.Pessoas.SingleOrDefault(p => p.id.Equals(pessoa.id));

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

        private bool Exist(long? id)
        {
            return _contexto.Pessoas.Any(p => p.id.Equals(id));
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

            var result = _contexto.Pessoas.SingleOrDefault(p => p.id.Equals(Id));
            try
            {
                if(result == null) _contexto.Pessoas.Remove(result);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Pessoa LocalizarPorID(long Id)
        {
            return _contexto.Pessoas.SingleOrDefault(p => p.id.Equals(Id));
            //return new Pessoa
            //{
            //    id =1,
            //    Nome = "Alexandre",
            //    sobreNome = "Pinheiro",
            //    Endereco = "Rua Sàp Paulo, 1000",
            //    Genero = "Masculino"
            //};
        }

        public List<Pessoa> LocalizarTodas()
        {
            return _contexto.Pessoas.ToList();

            //List<Pessoa> pessoas = new List<Pessoa>();

            //for (int i = 0; i < 8; i++)
            //{
            //    Pessoa pessoa = MockPessoa(i);
            //    pessoas.Add(pessoa);
            //}

            //return pessoas;
        }

        //private Pessoa MockPessoa(int i)
        //{
        //    return new Pessoa
        //    {
        //        id = IncrementAndGet(),
        //        Nome = "Pessoa nome " + i,
        //        sobreNome = "Pessoa sobrenome " + i,
        //        Endereco = "Alguma Rua " + i ,
        //        Genero = "Genero " + i
        //    };
        //}

        //private long IncrementAndGet()
        //{
            
        //    return Interlocked.Increment(ref count);
        //}
    }
}
