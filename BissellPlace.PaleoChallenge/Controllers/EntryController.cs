using System;
using System.Linq;
using BissellPlace.PaleoChallenge.Framework;
using BissellPlace.PaleoChallenge.Framework.DataAccess;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using BissellPlace.PaleoChallenge.Framework.Http;
using System.Web.Http;
using BissellPlace.PaleoChallenge.Framework.Http.Models;

namespace BissellPlace.PaleoChallenge.Controllers
{
    public class EntryController : RestController<Entry, IEntryRepository>
    {
        private readonly IUserRepository _userRepo;
        private readonly IEntryRepository _repo;
        private readonly ISecurityUser _user;

        public EntryController(IUserRepository userRepo, IEntryRepository repo, ISecurityUser user) : base(repo)
        {
            _userRepo = userRepo;
            _repo = repo;
            _user = user;
        }

        // POST api/values
        public override ResponseWrapper<Entry> Post([FromBody]Entry value)
        {
            return ResponseWrapper<Entry>.Wrap(() =>
            {
                var user = _userRepo.Query(n => n.UserName == _user.UserName).First();                
                value.Challenger = user;
                value.TimeStamp = DateTime.Now;
                return _repo.Create(value);
            });
        }

    }
}
