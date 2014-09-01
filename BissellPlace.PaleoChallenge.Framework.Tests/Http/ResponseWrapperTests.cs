using System;
using System.Linq;
using BissellPlace.PaleoChallenge.Framework.Http.Models;
using FakeItEasy;
using Xunit;

namespace BissellPlace.PaleoChallenge.Framework.Tests.Http
{
    public class ResponseWrapperTests
    {
        [Fact]
        public void CanCreateResponseWrapper()
        {
            var wrapper = new ResponseWrapper<int>();
            
            Assert.NotNull(wrapper);
            Assert.True(wrapper.IsSuccess);            
        }

        [Fact]
        public void CreateResponseWrapperFromFunction()
        {
            var wrapper = ResponseWrapper<int>.Wrap(() => A<int>._);
            
            Assert.NotNull(wrapper);
            Assert.True(wrapper.IsSuccess);
            Assert.IsType<int>(wrapper.Model);
        }

        [Fact]
        public void CreateFailedResponseWrapperFromFunction()
        {
            var errorMessage = "test";
            var wrapper = ResponseWrapper<int>.Wrap(() => { throw new Exception(errorMessage); });

            Assert.NotNull(wrapper);
            Assert.False(wrapper.IsSuccess);
            Assert.Equal(3, wrapper.Messages.Count);
            Assert.Equal(errorMessage, wrapper.Messages.First().Data.ToString());

        }
    }
}
