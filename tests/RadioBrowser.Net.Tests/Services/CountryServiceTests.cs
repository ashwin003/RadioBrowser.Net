namespace RadioBrowser.Net.Tests.Services
{
    public class CountryServiceTests
    {
        private readonly Mock<IApiService> mockApiService;
        private readonly ICountryService sut;
        private readonly CancellationToken cancellationToken = default;

        public CountryServiceTests()
        {
            mockApiService = new Mock<IApiService>();
            sut = new CountryService(mockApiService.Object);
        }

        [Test]
        public async Task ShouldReturnTheExpectedResultForCountries()
        {
            // Arrange
            var numberOfCountries = 10;
            var country = new Country();
            var expectedCountries = Enumerable.Repeat(country, numberOfCountries);
            mockApiService.Setup(m => m.ProcessRequest<IEnumerable<Country>>(It.Is<RequestPayload>(r => r.ResourceUri == "countries"), cancellationToken))
                          .ReturnsAsync(expectedCountries);

            // Act
            var countries = await sut.FetchAsync(null, cancellationToken);

            // Assert
            mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Country>>(It.Is<RequestPayload>(r => r.ResourceUri == "countries"), cancellationToken), Times.Once);
            Assert.That(countries, Is.EqualTo(expectedCountries));
        }
    }
}
