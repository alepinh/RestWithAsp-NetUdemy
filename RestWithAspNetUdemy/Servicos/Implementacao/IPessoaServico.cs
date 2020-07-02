using RestWithAspNetUdemy.Model;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.RestWithAspNetUdemy.Servicos.Implementacao
{
    public interface IPessoaServico
    {
        Pessoa Criar(Pessoa pessoa);
        Pessoa LocalizarPorID(long ID);
        List<Pessoa> LocalizarTodas();
        Pessoa Atualizar(Pessoa pessoa);
        void Excluir(long Id);
    }
}
