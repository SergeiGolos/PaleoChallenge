using System.Collections.Generic;
using System.Web.Http;
using PaleoChallenge.UI.Models;

namespace PaleoChallenge.UI.Interfaces
{
    public interface IRestController<TModel>
    {        
        RequestResult<IEnumerable<TModel>> Get();
        RequestResult<TModel> Get(int id);
        RequestResult<TModel> Post([FromBody]TModel value);
        RequestResult<TModel> Put(int id, [FromBody]TModel value);
        RequestResult<bool> Delete(int id);
    }
}