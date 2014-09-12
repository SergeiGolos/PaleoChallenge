using System;

namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class CommentEntry : LinkEntry<CommentEntry>
    {
        public string Comment { get; set; }
        public bool IsPublic { get; set; }    
    }
}
