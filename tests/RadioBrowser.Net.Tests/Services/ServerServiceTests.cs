namespace RadioBrowser.Net.Tests.Services;

public class ServerServiceTests {
    private readonly Mock<IApiService> mockApiService;
    private readonly IServerService sut;
    private readonly CancellationToken cancellationToken = default;

    public ServerServiceTests() {
        mockApiService = new Mock<IApiService>();
        sut = new ServerService(mockApiService.Object);
    }

    [Test]
    public async Task ShouldReturnExpectedStats() {
        // Arrange
        var expectedStats = new ServerStat();
        mockApiService.Setup(m => m.ProcessRequest<ServerStat>(It.Is<RequestPayload>(r => r.ResourceUri == "stats"), cancellationToken)).ReturnsAsync(expectedStats);

        // Act
        var stats = await sut.FetchAsync(cancellationToken);

        // Assert
        Assert.That(stats, Is.EqualTo(expectedStats));
        mockApiService.Verify(m => m.ProcessRequest<ServerStat>(It.Is<RequestPayload>(r => r.ResourceUri == "stats"), cancellationToken), Times.Once);
    }

    [Test]
    public async Task ShouldReturnExpectedMirrors() {
        // Arrange
        var mirror = new ServerMirror();
        var expectedMirrors = Enumerable.Repeat(mirror, 10);
        mockApiService.Setup(m => m.ProcessRequest<IEnumerable<ServerMirror>>(It.Is<RequestPayload>(r => r.ResourceUri == "servers"), cancellationToken)).ReturnsAsync(expectedMirrors);

        // Act
        var mirrors = await sut.FetchMirrorsAsync(cancellationToken);

        // Assert
        Assert.That(mirrors, Is.EqualTo(expectedMirrors));
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<ServerMirror>>(It.Is<RequestPayload>(r => r.ResourceUri == "servers"), cancellationToken), Times.Once);
    }
}