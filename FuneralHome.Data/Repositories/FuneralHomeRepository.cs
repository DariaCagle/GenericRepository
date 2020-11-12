using AutoMapper;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Internal;
using FuneralHome.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

        public TEntity GetById(int id)
        {
            return _dbSet
                .Find(id);
        }

        public void Update(TEntity model, int id)
        {
            var entity = GetById(id);

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

