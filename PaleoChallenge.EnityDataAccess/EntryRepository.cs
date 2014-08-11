using System.Linq.Expressions;
using AutoMapper;
using PaleoChallenge.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaleoChallenge.Business.DomainModel;

namespace PaleoChallenge.EnityDataAccess
{
    public class EntryRepository: RestRepository<Entry>, IEntryRepository
    {
        public EntryRepository(IMappingEngine mappingEngine) : base(mappingEngine)
        {
            Data = new Entry[]
            {
                new Entry() { Data = "Test", Id = 1}
            };
        }
    }
}
