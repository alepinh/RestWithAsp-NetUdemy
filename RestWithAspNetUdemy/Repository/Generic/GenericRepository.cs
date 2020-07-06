using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Model.Base;
using RestWithAspNetUdemy.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNetUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContexto _contexto;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContexto contexto)
        {
            _contexto = contexto;
            _dataset = _contexto.Set<T>();
        }
        public T Atualizar(T item)
        {
            if (!Exist(item.Id)) return null;

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                _contexto.Entry(result).CurrentValues.SetValues(item);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public T Criar(T item)
        {
            try
            {
                _dataset.Add(item);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public void Excluir(long Id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(Id));
            try
            {
                if (result != null) _dataset.Remove(result);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public T LocalizarPorID(long Id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(Id));
        }

        public List<T> LocalizarTodas()
        {
            return _dataset.ToList();
        }
    }
}
