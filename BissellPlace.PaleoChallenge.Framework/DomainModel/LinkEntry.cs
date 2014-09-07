namespace BissellPlace.PaleoChallenge.Framework.DomainModel
{
    public interface ILinkEntry
    {
        Entry Record { get; set; }
        string Type { get; }
        object Data { get; }
    }

    public class LinkEntry<T> : ILinkEntry, IStoredData
    {
        public int Id { get; set; }
        public Entry Record { get; set; }

        public virtual string Type
        {
            get { return typeof (T).Name; }
        }
        public virtual object Data { get; private set; }
    }
}