using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PaleoChallenge.Business;
using PaleoChallenge.UI.Interfaces;
using PaleoChallenge.UI.Models;

namespace PaleoChallenge.UI.Controllers
{    
    public abstract class RestController<TModel, TRepository> : ApiController, IRestController<TModel> 
        where TRepository : IRestRepository<TModel>
        where TModel : IStoredData, new()
    {
        /// <summary>
        /// The current repository ot use for the controller.
        /// </summary>
        private readonly TRepository _repository;

        private readonly IMappingEngine _mappingEngine;

        protected RestController(TRepository repository, IMappingEngine mappingEngine)
        {
            _repository = repository;
            _mappingEngine = mappingEngine;
        }

        /// <summary>
        /// 
        /// </summary>
        protected TRepository Repository { get { return _repository; } }

        
        // GET api/values
        public RequestResult<IEnumerable<TModel>> Get()
        {
            return RequestResult<IEnumerable<TModel>>.Wrap(() => Repository.Query((item) => true));
        }

        // GET api/values/5
        public RequestResult<TModel> Get(int id)
        {
            return RequestResult<TModel>.Wrap(() => Repository.Get(id));
        }

        // POST api/values
        public RequestResult<TModel> Post([FromBody]TModel value)
        {
            return RequestResult<TModel>.Wrap(() => Repository.Create(value));
        }

        // PUT api/values/5
        public RequestResult<TModel> Put(int id, [FromBody]TModel value)
        {
            return RequestResult<TModel>.Wrap(() => Repository.Save(id, value));
        }

        // DELETE api/values/5
        public RequestResult<bool> Delete(int id)
        {
            return RequestResult<bool>.Wrap(() => Repository.Delete(id));
        }
    }
}
