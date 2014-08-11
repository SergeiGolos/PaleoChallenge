﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaleoChallenge.Business.DomainModel;

namespace PaleoChallenge.Business.DataAccess
{
    public interface IUserRepository : IRestRepository<User>
    {
    }
}
