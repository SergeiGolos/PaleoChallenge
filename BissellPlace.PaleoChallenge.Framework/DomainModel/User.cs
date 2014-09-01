using System;

namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class User : IStoredData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime LastAccess { get; set; }
    }
}