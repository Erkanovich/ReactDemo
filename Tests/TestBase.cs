using System.Net.Http;
using Xunit;

namespace Tests
{
    public class TestBase : IClassFixture<TestWebApplicationFactory<TestStartup>>
    {
        protected readonly HttpClient Client;
        private readonly TestWebApplicationFactory<TestStartup> _factory;
        public TestBase(TestWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
        }
    }
}
