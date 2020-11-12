using AutoMapper;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FuneralHome.Data.Repositories
{
    public class FuneralHomeRepository<TEntity> : IFuneralRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;

        public FuneralHomeRepository(DbContext context)
        {
            _ctx = context;
            _dbSet = _ctx.Set<TEntity>();

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet
                .AsNoTracking()
                .ToList();
        }

        public TEntity GetBy(Func<TEntity, bool> func)
        {
            return _dbSet
                .FirstOrDefault(func);
        }

        public void Update(TEntity model, int id, Func<TEntity, bool> func)
        {

            var entity = GetBy(func);

            IMapper _mapper;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TEntity>();
            });
            _mapper = config.CreateMapper();

            _mapper.Map(model, entity);

            _ctx.SaveChanges();

        }
        public void Remove(TEntity model)
        {
            _dbSet.Remove(model);
            _ctx.SaveChanges();
        }

        public TEntity Create(TEntity model)
        {
            var entity = _dbSet.Add(model);
            _ctx.SaveChanges();
            return entity;
        }
    }
}

