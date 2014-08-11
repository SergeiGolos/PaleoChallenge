using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PaleoChallenge.Business;

namespace PaleoChallenge.EnityDataAccess
{
    public class RestRepository<TModel> : IRestRepository<TModel>
        where TModel : IStoredData, new()
    {
        private readonly IMappingEngine _mappingEngine;

        public RestRepository(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        protected IList<TModel> Data; 

        public IEnumerable<TModel> Query(Expression<Func<TModel, bool>> expression)
        {            
            return this.Data.AsQueryable().Where(expression).ToList();
        }

        public TModel Get(int id)
        {
            return this.Data.First(item => item.Id == id);
        }

        public TModel Create(TModel item)
        {
            item.Id = this.Data.Max(n => n.Id) + 1;
            this.Data.Add(item);
            return item;
        }

        public TModel Save(int id, TModel item)
        {
            var lookup = Get(id);
            if (lookup == null)
            {
                throw new Exception("Could not locate update record.");
            }
            _mappingEngine.Map(item, lookup);            
            return lookup;
        }

        public bool Delete(int id)
        {
            var item = Get(id);
            this.Data.Remove(item);
            return true;
        }
    }
}