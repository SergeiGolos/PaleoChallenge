namespace PaleoChallenge.Business.DomainModel
{
    public class User : IStoredData
    {
        public int Id { get; set; }
        public string UserName { get; set; }        
    }
}