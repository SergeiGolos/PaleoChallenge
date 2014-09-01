using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Framework.Http.Models;

namespace BissellPlace.PaleoChallenge.Framework.Http
{
    /// <summary>
    /// A base implementation of a rest controller. 
    /// </summary>
    /// <typeparam name="TModel">The model type for the controller to handle.</typeparam>
    /// <typeparam name="TRepo">The repository for the model the controller request.</typeparam>
    public abstract class RestController<TModel, TRepo> : ApiController
        where TRepo : IRestRepository<TModel> 
        where TModel : IStoredData, new()
    {
        
        private readonly TRepo _repo;

        public RestController(TRepo repo)
        {
            _repo = repo;
        }

        // GET api/values
        public virtual ResponseWrapper<IEnumerable<TModel>> Get()
        {
            return ResponseWrapper<IEnumerable<TModel>>.Wrap(() => _repo.Query(n => true));
        }

        // GET api/values/5
        public virtual ResponseWrapper<TModel> Get(int id)
        {
            return ResponseWrapper<TModel>.Wrap(() => _repo.Get(id));
        }

        // POST api/values
        public virtual ResponseWrapper<TModel> Post([FromBody]TModel value)
        {
            return ResponseWrapper<TModel>.Wrap(() => _repo.Create(value));
        }

        // PUT api/values/5
        public virtual ResponseWrapper<TModel> Put(int id, [FromBody]TModel value)
        {
            return ResponseWrapper<TModel>.Wrap(() => _repo.Save(id, value));
        }

        // DELETE api/values/5
        public virtual ResponseWrapper<bool> Delete(int id)
        {
            return ResponseWrapper<bool>.Wrap(() => _repo.Delete(id));
        }
    }
}
