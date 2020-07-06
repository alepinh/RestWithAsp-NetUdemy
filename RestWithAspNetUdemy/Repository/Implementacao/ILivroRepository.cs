using RestWithAspNetUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Repository.Implementacao
{
    public interface ILivroRepository
    {
        Livro Criar(Livro livro);
        Livro LocalizarPorID(long ID);
        List<Livro> LocalizarTodas();
        Livro Atualizar(Livro livro);
        void Excluir(long Id);
        bool Exist(long? id);
    }
}
