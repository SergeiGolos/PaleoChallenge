
using System.Collections.Generic;
using AutoMapper;

namespace PaleoChallenge.EnityDataAccess
{
    using PaleoChallenge.Business.DataAccess;
    using PaleoChallenge.Business.DomainModel;

    /// <summary>
    /// The user repository.
    /// </summary>
    public class UserRepository : RestRepository<User>, IUserRepository
    {
        public UserRepository(IMappingEngine mappingEngine)
            : base(mappingEngine)
        {
            Data = new List<User>()
            {
                new User() { Id = 1, UserName = "Serge" },                
                new User() { Id = 2, UserName = "Nicki" },
                new User() { Id = 3, UserName = "Dave" },
            };
        }
    }
}
