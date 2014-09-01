using System;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using BissellPlace.PaleoChallenge.EntityDataProvider;
using BissellPlace.PaleoChallenge.EntityDataProvider.Repositories;
using BissellPlace.PaleoChallenge.Framework.DataAccess;
using FakeItEasy;
using Xunit;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using System.Data.Entity;

namespace BissellPlace.PaleoChallenge.Tests.Entity
{
    public class EntryRepositoryTests : IDisposable
    {

        private IDbSet<Entry> _dbSet;
        private IEntryRepository _repo;
        private IDbContext _paleoChallengeContext;
        private IMappingEngine _mappingEngine;

        public EntryRepositoryTests()
        {
            _dbSet = A.Fake<IDbSet<Entry>>();
            _paleoChallengeContext = A.Fake<IDbContext>();
            _mappingEngine = A.Fake<IMappingEngine>();
            _repo = new EntryRepository(_paleoChallengeContext, _mappingEngine);
            
            A.CallTo(() => _paleoChallengeContext.Set<Entry>()).Returns(_dbSet);
            A.CallTo(() => _dbSet.Find(A<int>._)).ReturnsLazily(n => new Entry()
            {
                Id =(int)((object[])(n.Arguments[0]))[0]
            });
            
        }        

        [Fact]
        public void CanCreateRecord()
        {
            var add = A.CallTo(() => _dbSet.Add(A<Entry>._));
            add.Returns(new Entry() {Id = 1});
            var result = _repo.Create(new Entry());

            add.MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal(1, result.Id);            
        }


        [Fact]
        public void CanSaveRecord()
        {                 
            A.CallTo(() => _mappingEngine.Map(A<Entry>._, A<Entry>._)).Returns(new Entry() {Id = 1});                        
            var result = _repo.Save(1, new Entry());
            A.CallTo(() => _dbSet.Find(A<int>._)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void CanLoadRecord()
        {
            var result = _repo.Get(1);
            A.CallTo(() => _dbSet.Find(A<int>._)).MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void CanFailSaveRecord()
        {
            var result = new Entry();
            A.CallTo(() => _dbSet.Find(A<int>._)).Returns(null);
                        
            Assert.Throws<Exception>(() => result = _repo.Save(1, new Entry()));
            A.CallTo(() => _dbSet.Find(A<int>._)).MustHaveHappened(Repeated.Exactly.Once);         
        }


        [Fact]
        public void CanDeleteRecord()
        {
   
            _repo.Delete(1);

            A.CallTo(() => _dbSet.Find(A<int>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => _dbSet.Remove(A<Entry>._)).MustHaveHappened(Repeated.Exactly.Once);
        }

        public void Dispose()
        {
            _paleoChallengeContext.Dispose();
            
        }
    }
}