namespace RadioBrowser.Net.Tests.Services {
    public class LanguageServiceTests {
        private readonly Mock<IApiService> mockApiService;
        private readonly ILanguageService sut;
        private readonly CancellationToken cancellationToken = default;

        public LanguageServiceTests() {
            mockApiService = new Mock<IApiService>();
            sut = new LanguageService(mockApiService.Object);
        }

        [Test]
        public async Task ShouldReturnTheExpectedResultForLanguages() {
            // Arrange
            var numberOfLanguages = 10;
            var language = new Language();
            var expectedLanguages = Enumerable.Repeat(language, numberOfLanguages);
            mockApiService.Setup(m => m.ProcessRequest<IEnumerable<Language>>(It.IsAny<RequestPayload>(), cancellationToken))
                          .ReturnsAsync(expectedLanguages);

            // Act
            var languages = await sut.FetchAsync(null, cancellationToken);

            // Assert
            mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Language>>(It.IsAny<RequestPayload>(), cancellationToken), Times.Once);
            Assert.That(languages, Is.EqualTo(expectedLanguages));
        }
    }
}
