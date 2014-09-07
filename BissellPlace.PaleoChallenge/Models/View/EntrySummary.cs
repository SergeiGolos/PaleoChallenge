using System.Collections;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using System.Collections.Generic;

namespace BissellPlace.PaleoChallenge.Models.View
{
    public class EntrySummary : Entry, ILinkEntry
    {        
        
        public Entry Record { get; set; }
        public string Type { get; private set; }
        public object Data { get; private set; }
    }
}