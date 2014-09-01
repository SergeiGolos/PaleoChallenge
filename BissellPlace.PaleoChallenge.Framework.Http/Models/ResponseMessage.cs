namespace BissellPlace.PaleoChallenge.Framework.Http.Models
{
    /// <summary>
    /// A model used to wrap result wrapper messages.
    /// </summary>
    public class ResponseMessage
    {
        public ResponseMessage()
        {
            Type = string.Empty;
        }

        public ResponseMessage(object data) : this()
        {
            Data = data;
        }

        public ResponseMessage(string type, object data) : this(data)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        /// <summary>
        /// The type is a marker allowing different types of data to be sent down
        /// the client and be precessed different.  This is a runtime binding.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the message data.
        /// </summary>
        public object Data { get; set; }
    }
}