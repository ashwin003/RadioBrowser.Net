using RadioBrowser.Net.Entities;
using System;
using System.Xml.Linq;

namespace RadioBrowser.Net.Tests.Services;

public class StationServiceTests {
    private readonly Mock<IApiService> mockApiService;
    private readonly IStationService sut;
    private readonly CancellationToken cancellationToken = default;

    public StationServiceTests() {
        mockApiService = new Mock<IApiService>();
        sut = new StationService(mockApiService.Object);
    }

    [Test]
    public async Task ShouldReturnTheExpectedResultForAdvancedSearch() {
        // Arrange
        var resourceUri = "stations/search";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.AdvancedSearchAsync(new AdvancedStationSearch { }, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByUUID() {

        // Arrange
        var guid = Guid.NewGuid();
        var resourceUri = "stations/byuuid/{guid}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var station = await sut.FetchByUUIDAsync(guid, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(station, Is.EqualTo(expectedStations.First()));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByName() {

        // Arrange
        var name = "Name";
        var resourceUri = "stations/byname/{name}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByNameAsync(name, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByNameExactMatch() {

        // Arrange
        var name = "Name";
        var resourceUri = "stations/bynameexact/{name}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByNameAsync(name, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByCodec() {

        // Arrange
        var codec = "MP3";
        var resourceUri = "stations/bycodec/{codec}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByCodecAsync(codec, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByCodecExactMatch() {

        // Arrange
        var codec = "MP3";
        var resourceUri = "stations/bycodecexact/{codec}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByCodecAsync(codec, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByCountry() {

        // Arrange
        var country = "Australia";
        var resourceUri = "stations/bycountry/{country}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByCountryAsync(country, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByCountryExactMatch() {

        // Arrange
        var country = "Australia";
        var resourceUri = "stations/bycountryexact/{country}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByCountryAsync(country, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByState() {

        // Arrange
        var state = "State";
        var resourceUri = "stations/bystate/{state}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByStateAsync(state, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByStateExactMatch() {

        // Arrange
        var state = "State";
        var resourceUri = "stations/bystateexact/{state}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByStateAsync(state, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByLanguage() {

        // Arrange
        var language = "English";
        var resourceUri = "stations/bylanguage/{language}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByLanguageAsync(language, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByLanguageExactMatch() {

        // Arrange
        var language = "English";
        var resourceUri = "stations/bylanguageexact/{language}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByLanguageAsync(language, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByTag() {

        // Arrange
        var tag = "Tag";
        var resourceUri = "stations/bytag/{tag}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByTagAsync(tag, false, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationByTagExactMatch() {
        // Arrange
        var language = "Tag";
        var resourceUri = "stations/bytagexact/{tag}";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchByTagAsync(language, true, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStation() {
        // Arrange
        var resourceUri = "stations";
        var expectedStations = SetupStations(resourceUri);

        // Act
        var stations = await sut.FetchAsync(null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(stations, Is.EqualTo(expectedStations));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationChecks() {
        // Arrange
        var resourceUri = "checks";
        var expectedChecks = SetupStationChecks(resourceUri);

        // Act
        var checks = await sut.FetchChecksAsync(null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<StationCheck>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(checks, Is.EqualTo(expectedChecks));
    }

    [Test]
    public async Task ShouldReturnTheExpectedStationChecksWithGuid() {
        // Arrange
        var guid = Guid.NewGuid();
        var resourceUri = "checks/{id}";
        var expectedChecks = SetupStationChecks(resourceUri);

        // Act
        var checks = await sut.FetchChecksAsync(guid, null, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<IEnumerable<StationCheck>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(checks, Is.EqualTo(expectedChecks));
    }

    [Test]
    public async Task ShouldReturnTheExpectedResultWhenRegisteringClick() {
        // Arrange
        var guid = Guid.NewGuid();
        var resourceUri = guid.ToString();
        var expectedResponse = new StationClickResponse();
        mockApiService.Setup(m => m.ProcessRequest<StationClickResponse>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken))
                     .ReturnsAsync(expectedResponse);

        // Act
        var response = await sut.RegisterClick(guid, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<StationClickResponse>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(response, Is.EqualTo(expectedResponse));
    }

    [Test]
    public async Task ShouldReturnTheExpectedResultWhenRegisteringVote() {
        // Arrange
        var guid = Guid.NewGuid();
        var resourceUri = "vote/{id}";
        var expectedResponse = new StationVoteResponse();
        mockApiService.Setup(m => m.ProcessRequest<StationVoteResponse>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken))
                     .ReturnsAsync(expectedResponse);

        // Act
        var response = await sut.RegisterVote(guid, cancellationToken);

        // Assert
        mockApiService.Verify(m => m.ProcessRequest<StationVoteResponse>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken), Times.Once);
        Assert.That(response, Is.EqualTo(expectedResponse));
    }

    private IEnumerable<Station> SetupStations(string resourceUri) {
        var numberOfStations = 10;
        var station = new Station();
        var stations = Enumerable.Repeat(station, numberOfStations).ToList();
        mockApiService.Setup(m => m.ProcessRequest<IEnumerable<Station>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken))
                      .ReturnsAsync(stations);
        return stations;
    }

    private IEnumerable<StationCheck> SetupStationChecks(string resourceUri) {
        var numberOfChecks = 10;
        var check = new StationCheck();
        var stations = Enumerable.Repeat(check, numberOfChecks).ToList();
        mockApiService.Setup(m => m.ProcessRequest<IEnumerable<StationCheck>>(It.Is<RequestPayload>(r => r.ResourceUri == resourceUri), cancellationToken))
                      .ReturnsAsync(stations);
        return stations;
    }
}