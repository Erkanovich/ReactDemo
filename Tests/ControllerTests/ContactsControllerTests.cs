using Data;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReactDemo;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.ControllerTests
{
    public class ContactsControllerTests : TestBase
    {
        public ContactsControllerTests(TestWebApplicationFactory<TestStartup> factory) : base(factory)
        {  }


        // Just example, not actually a test against ContactsController
        [Theory]
        [InlineData("sodas")]
        [InlineData("httpAndRest/hello")]
        public async Task ExampleTest(string value) 
        {
            var response = await Client.GetAsync(value);
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            (await response.Content.ReadAsStringAsync())
                .Length
                .Should()
                .BeGreaterThan(10);
        }

        [Fact]
        public async Task Should_Return_OK_When_Posting()
        {
            var requestData = new ContactMeRequest
            {
                Email = "test@test.com",
                Message = "I love testing",
                Name = "My old collegue"
            };
            var requestDataAsJson = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("contacts", httpContent);
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Data_Should_Be_Saved_Correctly_When_Posting()
        {
            var requestData = new ContactMeRequest
            {
                Email = "test@test.com",
                Message = "I love testing",
                Name = "My old collegue"
            };
            var requestDataAsJson = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(requestDataAsJson, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("contacts", httpContent);
            var entityInDatabase = await Context.ContactMes.FirstOrDefaultAsync(x => x.Email == "test@test.com");
            entityInDatabase.Message.Should().Be("I love testing");
            entityInDatabase.Name.Should().Be("My old collegue");
        }
    }
}
