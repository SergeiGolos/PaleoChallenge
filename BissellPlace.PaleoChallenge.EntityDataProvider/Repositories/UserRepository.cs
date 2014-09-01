﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using BissellPlace.PaleoChallenge.Framework.DataAccess;
using BissellPlace.PaleoChallenge.Framework.DomainModel;

namespace BissellPlace.PaleoChallenge.EntityDataProvider.Repositories
{
    /// <summary>
    /// Provides an access point for getting Entry items from an entity framework source.
    /// </summary>
    public class UserRepository : RestRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context, IMappingEngine mappingEngine) : base(context, mappingEngine)
        {
        }
    }
}