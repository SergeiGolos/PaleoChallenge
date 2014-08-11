using AutoMapper;

namespace PaleoChallenge.UI.Controllers
{
    using PaleoChallenge.Business.DataAccess;
    using PaleoChallenge.Business.DomainModel;

    public class UserController : RestController<User, IUserRepository>
    {
        public UserController(IUserRepository repository, IMappingEngine mappingEngine)
            : base(repository, mappingEngine)
        {
        }
    }
}
