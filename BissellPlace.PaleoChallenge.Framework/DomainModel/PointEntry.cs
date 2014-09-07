namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class PointEntry : LinkEntry<PointEntry>
    {        
        public int Points { get; set; }
        public int Bonus { get; set; }        
    }
}