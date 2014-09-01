using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.EntityDataProvider
{
    public class RestRepository<TModel> : IRestRepository<TModel>
        where TModel : class, IStoredData, new()
    {
        protected readonly IDbContext DbContext;
        protected readonly IMappingEngine Mapper;

        public RestRepository(IDbContext dbContext, IMappingEngine mappingEngine)
        {
            DbContext = dbContext;
            Mapper = mappingEngine;
        }

        public IEnumerable<TModel> Query(Expression<Func<TModel, bool>> expression)
        {
            return this.DbContext.Set<TModel>().AsQueryable().Where(expression).ToList();
        }

        public TModel Get(int id)
        {
            return this.DbContext.Set<TModel>().Find(id);
        }

        public TModel Create(TModel item)
        {
            var model = this.DbContext.Set<TModel>().Add(item);
            this.DbContext.SaveChanges();
            
            return model;
        }

        public TModel Save(int id, TModel item)
        {
            var lookup = Get(id);
            if (lookup == null)
            {
                throw new Exception("Could not locate update record.");
            }

            var model = Mapper.Map(item, lookup);
            this.DbContext.SaveChanges();

            return model;            
        }

        public bool Delete(int id)
        {
            var loaded = Get(id);
            this.DbContext.Set<TModel>().Remove(loaded);
            this.DbContext.SaveChanges();
            return true;
        }
    }
}
