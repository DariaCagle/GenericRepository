using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FuneralHome.Data.Interfaces
{
    public interface IFuneralRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity model);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity model);
        void Update(TEntity model, int id);


    }
}
