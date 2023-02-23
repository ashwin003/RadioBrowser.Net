namespace RadioBrowser.Net.Tests.Services {
    public class CodecServiceTests {
        private readonly Mock<IApiService> mockApiService;
        private readonly ICodecService sut;
        private readonly CancellationToken cancellationToken = default;

        public CodecServiceTests()
        {
            mockApiService = new Mock<IApiService>();
            sut = new CodecService(mockApiService.Object);
        }

        [Test]
        public async Task ShouldReturnTheExpectedResult() {
            // Arrange
            var numberOfCodecs = 10;
            var codec = new Codec();
            var expectedCountries = Enumerable.Repeat(codec, numberOfCodecs);
            mockApiService.Setup(m => m.ProcessRequest<IEnumerable<Codec>>(It.Is<RequestPayload>(r => r.ResourceUri == "codecs"), cancellationToken))
                          .ReturnsAsync(expectedCountries);

            // Act
            var countries = await sut.FetchAsync(null, cancellationToken);

            // Assert
            mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Codec>>(It.Is<RequestPayload>(r => r.ResourceUri == "codecs"), cancellationToken), Times.Once);
            Assert.That(countries, Is.EqualTo(expectedCountries));
        }
    }
}
