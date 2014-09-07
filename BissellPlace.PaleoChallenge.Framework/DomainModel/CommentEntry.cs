using System;

namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class CommentEntry : LinkEntry<CommentEntry>
    {
        public string Data { get; set; }
        public bool IsPublic { get; set; }    
    }
}
