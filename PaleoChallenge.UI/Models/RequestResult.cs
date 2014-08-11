using System;
using System.Collections.Generic;

namespace PaleoChallenge.UI.Models
{
    /// <summary>
    /// A wrapper object for returning data from the server.  This object can store 
    /// the success/un-success state as well as a number of additional messSages.
    /// </summary>
    /// <typeparam name="TModel">The model of the type that being returned.</typeparam>
    public class RequestResult<TModel>
    {
        /// <summary>
        /// A wrapper function to simplify wrapping request results for data.
        /// </summary>
        /// <param name="fn">Expression that results with the value to be wrapped.</param>
        /// <returns>The request result wrap of model.</returns>
        public static RequestResult<TModel> Wrap(Func<TModel> fn)
        {
            var result = new RequestResult<TModel>()
            {
                IsSuccess = true
            };

            try
            {
                result.Model = fn();                
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Messages = new List<object>{ ex };
            }

            return result;
        }

        public TModel Model { get; set; }
        
        public bool IsSuccess { get; set; }
        
        public IList<object> Messages { get; set; }        
    }
}