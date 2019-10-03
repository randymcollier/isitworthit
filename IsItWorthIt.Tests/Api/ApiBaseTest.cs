using NUnit.Framework;

namespace IsItWorthIt.Tests.Api
{
    [TestFixture, Category("Integration")]
    public class ApiBaseTest
    {
        private ApiWebApplicationFactory _factory { get; set; }
        protected ApiTestClient _apiClient { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new ApiWebApplicationFactory();
            var http = _factory.CreateClient();
            _apiClient = new ApiTestClient(http);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _apiClient?.Dispose();
            _factory?.Dispose();
        }
    }
}