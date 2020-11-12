using System;
using System.Collections.Generic;

namespace FuneralHome.Data.Interfaces
{
    public interface IFuneralRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity model);
        TEntity GetBy(Func<TEntity, bool> func);
        IEnumerable<TEntity> GetAll();
        void Remove(TEntity model);
        void Update(TEntity model, int id, Func<TEntity, bool> func);


    }
}
