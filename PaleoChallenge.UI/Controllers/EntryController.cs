using AutoMapper;

namespace PaleoChallenge.UI.Controllers
{
    using PaleoChallenge.Business.DataAccess;
    using PaleoChallenge.Business.DomainModel;

    public class EntryController : RestController<Entry, IEntryRepository>
    {
        public EntryController(IEntryRepository repository, IMappingEngine mappingEngine)
            : base(repository, mappingEngine)
        {
        }
    }
}
