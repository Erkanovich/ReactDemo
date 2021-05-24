using Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Xunit;

namespace Tests
{
    public class TestBase : IClassFixture<TestWebApplicationFactory<TestStartup>>
    {
        protected readonly HttpClient Client;
        private readonly TestWebApplicationFactory<TestStartup> _factory;
        protected readonly CurriculumVitaeDbContext Context;
        public TestBase(TestWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            Context = _factory.Server.Services.GetService(typeof(CurriculumVitaeDbContext)) as CurriculumVitaeDbContext;
            Context.Database.EnsureCreated();
        }
    }
}
