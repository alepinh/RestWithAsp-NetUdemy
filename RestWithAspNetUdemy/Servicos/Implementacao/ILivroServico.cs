using RestWithAspNetUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Servicos.Implementacao
{
    public interface ILivroServico 
    {
        LivroVO Criar(LivroVO livro);
        LivroVO LocalizarPorID(long ID);
        List<LivroVO> LocalizarTodas();
        LivroVO Atualizar(LivroVO livro);
        void Excluir(long Id);
    }
}
