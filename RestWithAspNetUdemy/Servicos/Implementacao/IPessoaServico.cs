using RestWithAspNetUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Servicos.Implementacao
{
    public interface IPessoaServico
    {
        PessoaVO Criar(PessoaVO pessoa);
        PessoaVO LocalizarPorID(long ID);
        List<PessoaVO> LocalizarTodas();
        PessoaVO Atualizar(PessoaVO pessoa);
        void Excluir(long Id);
    }
}
