namespace PaleoChallenge.Business.DomainModel
{
    public class EntryType : IStoredData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
    }
}