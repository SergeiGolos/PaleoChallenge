using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BissellPlace.PaleoChallenge.Framework.Http;
using FakeItEasy;
using Xunit;

namespace BissellPlace.PaleoChallenge.Framework.Tests.Http
{
    public class RestControllerTests
    {
        public class TestObject : IStoredData
        {
            public int Id { get; set; }
        }

        public class TestRestController : RestController<TestObject, IRestRepository<TestObject>>
        {
            public  TestRestController(IRestRepository<TestObject> repo) : base(repo)
            { }
        }

        private IRestRepository<TestObject> _repo;

        public RestControllerTests()
        {
            _repo = A.Fake<IRestRepository<TestObject>>();
        }


        [Fact]
        public void CreateRestController()
        {
            var controller = new TestRestController(_repo);
        }

        [Fact]
        public void CanRequestListData()
        {
            var query = A.CallTo(() => _repo.Query(A<Expression<Func<TestObject, bool>>>._));            
            query.Returns(new List<TestObject>
            {
                new TestObject() { Id = 1},
                new TestObject() { Id = 2}
            });
                        
            var result = (new TestRestController(_repo)).Get();
            
            query.MustHaveHappened(Repeated.Exactly.Once);
            Assert.True(result.IsSuccess);            
            Assert.Equal(2, result.Model.Count());            
        }


        [Fact]
        public void CanRequestSingleData()
        {
            const int id = 1;
            A.CallTo(() => _repo.Get(A<int>._)).ReturnsLazily(n=> new TestObject() { Id = (int)n.Arguments[0]});
            var result = (new TestRestController(_repo)).Get(1);
            
            Assert.True(result.IsSuccess);
            Assert.Equal(id, ((TestObject)result.Model).Id);
        }

        [Fact]
        public void CanPostData()
        {
            const int id = 1;
            var create = A.CallTo(() => _repo.Create(A<TestObject>._));
            create.ReturnsLazily(n => (TestObject)n.Arguments[0]);
                               
            var result = (new TestRestController(_repo)).Post(new TestObject() { Id = id });

            Assert.True(result.IsSuccess);
            Assert.Equal(id, ((TestObject)result.Model).Id);
            A.CallTo(() => _repo.Create(A<TestObject>._)).MustHaveHappened(Repeated.Exactly.Once);                        
        }
        
        [Fact]
        public void CanPutData()
        {
            const int id = 1;
            var create = A.CallTo(() => _repo.Save(A<int>._, A<TestObject>._));
            create.ReturnsLazily(n => new TestObject() { Id = (int)n.Arguments[0]});

            var result = (new TestRestController(_repo)).Put(id, new TestObject());

            Assert.True(result.IsSuccess);
            Assert.Equal(id, ((TestObject)result.Model).Id);
            create.MustHaveHappened(Repeated.Exactly.Once);
        }


        [Fact]
        public void CanDeleteData()
        {
            const int id = 1;
            var delete = A.CallTo(() => _repo.Delete(A<int>._));
            delete.Returns(true);

            var result = (new TestRestController(_repo)).Delete(id);

            Assert.True(result.IsSuccess);
            Assert.True(result.Model);
            delete.MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}