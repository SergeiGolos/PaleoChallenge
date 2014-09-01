using System;
using System.Linq;
using BissellPlace.PaleoChallenge.EntityDataProvider;
using BissellPlace.PaleoChallenge.Framework;
using BissellPlace.PaleoChallenge.Framework.DomainModel;

namespace BissellPlace.PaleoChallenge
{

    public class SingleSecurityUser : ISecurityUser
    {
        private const string SingleUserName = "SingleUser";

        public SingleSecurityUser(IDbContext context)
        {
            User user;
            
            var found = context.Set<User>().Where(n => n.UserName == SingleUserName);
             
            if (found.Any())
            {
                user = found.First();
            }            
            else
            {
                user = context.Set<User>().Add(new User() { UserName = SingleUserName});
                
            }
            user.LastAccess = DateTime.Now;
            UserName = user.UserName;
            
            context.SaveChanges();
        }

        public string UserName { get; private set; }
    }
}
