using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaleoChallenge.Business.DomainModel
{
    public class Entry : IStoredData
    {
        public int Id { get; set; }
        public User Challenger { get; set; }
        public EntryType Type { get; set; }
        public string Data { get; set; }
    }
}
