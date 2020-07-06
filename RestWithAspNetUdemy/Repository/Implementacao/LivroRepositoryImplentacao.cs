using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Implementacao
{
    public class LivroRepositoryImplentacao : ILivroRepository
    {
        //private volatile int count;

        private MySQLContexto _contexto;

        public LivroRepositoryImplentacao(MySQLContexto contexto)
        {
            _contexto = contexto;
        }

        public Livro Atualizar(Livro livro)
        {
            if(!Exist(livro.Id)) return null;

            var result = _contexto.Livros.SingleOrDefault(p => p.Id.Equals(livro.Id));

            try
            {
                _contexto.Entry(result).CurrentValues.SetValues(livro);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return livro;

        }

        public bool Exist(long? id)
        {
            return _contexto.Livros.Any(p => p.Id.Equals(id));
        }

        public Livro Criar(Livro livro)
        {
            try
            {
                _contexto.Add(livro);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return livro;
        }

        public void Excluir(long Id)
        {

            var result = _contexto.Livros.SingleOrDefault(p => p.Id.Equals(Id));
            try
            {
                if (result != null) _contexto.Livros.Remove(result);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Livro LocalizarPorID(long Id)
        {
            return _contexto.Livros.SingleOrDefault(p => p.Id.Equals(Id));
            //return new livro
            //{
            //    id =1,
            //    Nome = "Alexandre",
            //    sobreNome = "Pinheiro",
            //    Endereco = "Rua Sàp Paulo, 1000",
            //    Genero = "Masculino"
            //};
        }

        public List<Livro> LocalizarTodas()
        {
            return _contexto.Livros.ToList();

        }


    }
}
