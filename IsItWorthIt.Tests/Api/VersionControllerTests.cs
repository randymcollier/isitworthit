using System.Threading.Tasks;
using IsItWorthIt.Domain.Models;
using NUnit.Framework;

namespace IsItWorthIt.Tests.Api
{
    public class VersionControllerTests : ApiBaseTest
    {
        [Test]
        public async Task VersionController_Get_Returns200()
        {
            // Act
            var response = await _apiClient.GetAsync<Versioning>("/api/version").ConfigureAwait(false);

            // Assert
            Assert.True(response?.ResponseMessage?.IsSuccessStatusCode);
        }

        [Test]
        public async Task VersionController_Get_ReturnsString()
        {
            // Act
            var response = await _apiClient.GetAsync<Versioning>("/api/version").ConfigureAwait(false);

            // Assert
            Assert.NotNull(response?.Data);
        }
    }
}