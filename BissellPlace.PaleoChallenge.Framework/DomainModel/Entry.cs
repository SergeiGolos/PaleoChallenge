using System;

namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class Entry : IStoredData
    {
        public int Id { get; set; }
        public virtual User Challenger { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime TimeStamp { get; set; }    
    }
}
