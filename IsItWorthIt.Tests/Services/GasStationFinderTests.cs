using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IsItWorthIt.Domain.Models;
using IsItWorthIt.Domain.Services;
using IsItWorthIt.Domain.Utilities;
using IsItWorthIt.Tests.Utilities;
using Moq;
using NUnit.Framework;

namespace IsItWorthIt.Tests.Services
{
    [TestFixture, Category("Unit")]
    public class GasStationFinderTests
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _http;

        [SetUp]
        public void Setup()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _http = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _fakeHttpMessageHandler.Object.Dispose();
            _http.Dispose();
        }

        [Test]
        public async Task GasStationFinder_Find_MakesHttpRequest()
        {
            // Arrange
            var gasDataResponse = GasDataHelper.OK_EmptyStations();
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(gasDataResponse.ToJson())
            });
            var finder = new GasStationFinder(_http);

            // Act
            var result = await finder.Find(new GasDataRequest()).ConfigureAwait(false);

            // Assert
            _fakeHttpMessageHandler.Verify(f => f.Send(It.IsAny<HttpRequestMessage>()), Times.Once);
        }

        [Test]
        public async Task GasStationFinder_Find_ReturnsGasDataResponse()
        {
            // Arrange
            var gasDataResponse = GasDataHelper.OK_EmptyStations();
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(gasDataResponse.ToJson())
            });
            var finder = new GasStationFinder(_http);

            // Act
            var result = await finder.Find(new GasDataRequest()).ConfigureAwait(false);

            // Assert
            Assert.IsInstanceOf(typeof(GasDataResponse), result);
        }

        [Test, Category("Integration")]
        public async Task GasStationFinder_Find_CallsMyGasFeed()
        {
            // Arrange
            var finder = new GasStationFinder(new HttpClient());

            // Act
            var result = await finder.Find(new GasDataRequest()).ConfigureAwait(false);

            // Assert
            Assert.IsInstanceOf(typeof(GasDataResponse), result);
        }
    }
}