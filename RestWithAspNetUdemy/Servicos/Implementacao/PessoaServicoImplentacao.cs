using RestWithAspNetUdemy.Model;
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
        private volatile int count;

        public Pessoa Atualizar(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            return pessoa;
        }

        public void Excluir(long Id)
        {
            
        }

        public Pessoa LocalizarPorID(long ID)
        {
            return new Pessoa
            {
                id =1,
                Nome = "Alexandre",
                sobreNome = "Pinheiro",
                Endereco = "Rua Sàp Paulo, 1000",
                Genereo = "Masculino"
            };
        }

        public List<Pessoa> LocalizarTodas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                pessoas.Add(pessoa);
            }

            return pessoas;
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                id = IncrementAndGet(),
                Nome = "Pessoa nome " + i,
                sobreNome = "Pessoa sobrenome " + i,
                Endereco = "Alguma Rua " + i ,
                Genereo = "Genero " + i
            };
        }

        private long IncrementAndGet()
        {
            
            return Interlocked.Increment(ref count);
        }
    }
}
