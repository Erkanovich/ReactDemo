using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [Fact]
        public async Task ExampleTest() 
        {
            var response = await Client.GetAsync("sodas");
            response
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
            (await response.Content.ReadAsStringAsync())
                .Length
                .Should()
                .BeGreaterThan(10);
        }
    }
}
