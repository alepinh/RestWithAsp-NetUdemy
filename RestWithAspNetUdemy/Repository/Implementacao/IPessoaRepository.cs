using RestWithAspNetUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Repository.Implementacao
{
    public interface IPessoaRepository
    {
        Pessoa Criar(Pessoa pessoa);
        Pessoa LocalizarPorID(long ID);
        List<Pessoa> LocalizarTodas();
        Pessoa Atualizar(Pessoa pessoa);
        void Excluir(long Id);
        bool Exist(long? id);
    }
}
