using RestWithAspNetUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Criar(T item);
        T LocalizarPorID(long ID);
        List<T> LocalizarTodas();
        T Atualizar(T item);
        void Excluir(long Id);
        bool Exist(long? id);
    }
}
