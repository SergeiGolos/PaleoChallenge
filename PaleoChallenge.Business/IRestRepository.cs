using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PaleoChallenge.Business
{
    /// <summary>
    /// The interface for a rest repository implementation.
    /// </summary>
    /// <typeparam name="TModel">The model for which the repository is implemented for.</typeparam>
    public interface IRestRepository<TModel>
        where TModel : IStoredData, new()
    {
        IEnumerable<TModel> Query(Expression<Func<TModel, bool>> expression);            
        
        TModel Get(int id);

        TModel Create(TModel item);
        
        TModel Save(int id, TModel item);
        
        bool Delete(int id);
    }
}