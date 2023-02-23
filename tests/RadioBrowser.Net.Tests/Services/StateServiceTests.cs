namespace RadioBrowser.Net.Tests.Services {
    public class StateServiceTests {
        private readonly Mock<IApiService> mockApiService;
        private readonly IStateService sut;
        private readonly CancellationToken cancellationToken = default;

        public StateServiceTests() {
            mockApiService = new Mock<IApiService>();
            sut = new StateService(mockApiService.Object);
        }

        [Test]
        public async Task ShouldReturnTheExpectedResultForStates() {
            // Arrange
            var numberOfStates = 10;
            var state = new State();
            var expectedCountries = Enumerable.Repeat(state, numberOfStates);
            mockApiService.Setup(m => m.ProcessRequest<IEnumerable<State>>(It.IsAny<RequestPayload>(), cancellationToken))
                          .ReturnsAsync(expectedCountries);

            // Act
            var countries = await sut.FetchAsync(null, cancellationToken);

            // Assert
            mockApiService.Verify(m => m.ProcessRequest<IEnumerable<State>>(It.IsAny<RequestPayload>(), cancellationToken), Times.Once);
            Assert.That(countries, Is.EqualTo(expectedCountries));
        }
    }
}
