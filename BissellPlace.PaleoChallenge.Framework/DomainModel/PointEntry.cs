namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public class PointEntry : LinkEntry<PointEntry>
    {        
        public int Points { get; set; }
        public int Sleep { get; set; }
		public int Workout { get; set; }
    }
}