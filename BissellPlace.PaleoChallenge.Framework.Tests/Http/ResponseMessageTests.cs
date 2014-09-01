using BissellPlace.PaleoChallenge.Framework.Http.Models;
using FakeItEasy;
using Xunit;

namespace BissellPlace.PaleoChallenge.Framework.Tests.Http
{
    public class ResponseMessageTests
    {
        [Fact]
        public void CanCreateResponseMessage()
        {
            var responseMessage = new ResponseMessage();
            Assert.NotNull(responseMessage);
        }

        [Fact]
        public void CanSetData()
        {
            var responseMessage = new ResponseMessage(new {});

            Assert.NotNull(responseMessage.Data);
            Assert.True(string.IsNullOrEmpty(responseMessage.Type));
        }

        [Fact]
        public void CanSetType()
        {                        
            var responseMessage = new ResponseMessage("test", A<object>._);           
            
            Assert.NotNull(responseMessage.Type);
            Assert.Equal("test", responseMessage.Type);
        }
    }
}
