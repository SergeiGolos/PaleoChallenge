using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace BissellPlace.PaleoChallenge.Framework.Http.Models
{
    /// <summary>
    /// A wrapper object for returning data from the server.  This object can store 
    /// the success/un-success state as well as a number of additional messSages.
    /// </summary>
    /// <typeparam name="TModel">The model of the type that being returned.</typeparam>
    public class ResponseWrapper<TModel>
    {
        /// <summary>
        /// Creates a request wrapper with some default values.
        /// </summary>
        public ResponseWrapper()
        {
            IsSuccess = true;
            Messages = new List<ResponseMessage>();
        } 

        /// <summary>
        /// A wrapper function to simplify wrapping request results for data.
        /// </summary>
        /// <param name="fn">Expression that results with the value to be wrapped.</param>
        /// <returns>The request result wrap of model.</returns>
        public static ResponseWrapper<TModel> Wrap(Func<TModel> fn)
        {
            var result = new ResponseWrapper<TModel>();
            try
            {
                result.Model = fn();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                (new List<object> {ex.Message, ex.Source, ex.StackTrace})
                    .Select(n => new ResponseMessage() {
                        Data = n,
                        Type = "Error"
                    })
                    .ForEach(result.Messages.Add);
            }

            return result;
        }

        /// <summary>
        /// Gets or sets the requested model to the result wrapper.
        /// </summary>
        public TModel Model { get; set; }

        /// <summary>
        /// Gets or sets the success state of the request.
        /// </summary>        
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the list of message that need to be returned.
        /// </summary>
        public IList<ResponseMessage> Messages { get; set; }
    }
}
