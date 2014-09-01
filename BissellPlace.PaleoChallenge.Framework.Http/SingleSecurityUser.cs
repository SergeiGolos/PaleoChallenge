using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BissellPlace.PaleoChallenge.Framework.Http
{
    public class SingleSecurityUser : ISecurityUser
    {
        public SingleSecurityUser(IDbContext)
        {
            UserName = "SingleUser";
        }
        
        public string UserName { get; set; }
    }
}
