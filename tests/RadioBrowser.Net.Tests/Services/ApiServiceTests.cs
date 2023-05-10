using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RichardSzalay.MockHttp;

namespace RadioBrowser.Net.Tests.Services;

public class ApiServiceTests {
    private readonly MockHttpMessageHandler mockHttpMessageHandler;
    private readonly RestClient restClient;
    private readonly IApiService sut;

    public ApiServiceTests() {
        mockHttpMessageHandler = new MockHttpMessageHandler();
        restClient = new RestClient(new RestClientOptions { BaseUrl = new Uri("http://localhost/"), ConfigureMessageHandler = (_) => mockHttpMessageHandler }, configureSerialization: cfg => cfg.UseNewtonsoftJson());
        sut = new ApiService(restClient);

        SetupTestData("Stations", "stations/search");
        SetupTestData("Countries", "countries");
        SetupTestData("Codecs", "codecs");
        SetupTestData("States", "states");
        SetupTestData("Languages", "languages");
        SetupTestData("Tags", "tags");
        SetupTestData("StationChecks", "checks");
        SetupTestData("StationClicks", "clicks");
        SetupTestData("StationClickResponse", "clickresponse");
        SetupTestData("StationVoteResponse", "voteresponse");
        SetupTestData("ServerStat", "stats");
        SetupTestData("ServerMirrors", "servers");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForStations() {
        await ProcessRequest<List<Station>>("stations/search");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForCountries() {
        await ProcessRequest<List<Country>>("countries");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForCodecs() {
        await ProcessRequest<List<Codec>>("codecs");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForStates() {
        await ProcessRequest<List<State>>("states");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForLanguages() {
        await ProcessRequest<List<Language>>("languages");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForTags() {
        await ProcessRequest<List<Tag>>("tags");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForChecks() {
        await ProcessRequest<List<StationCheck>>("checks");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForClicks() {
        await ProcessRequest<List<StationClick>>("clicks");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForRegisterClickResponse() {
        await ProcessRequest<StationClickResponse>("clickresponse");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForRegisterVoteResponse() {
        await ProcessRequest<StationVoteResponse>("voteresponse");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForServerStat() {
        await ProcessRequest<ServerStat>("stats");
    }

    [Test]
    public async Task ShouldDeserializeDataAsExpectedForServerMirrors() {
        await ProcessRequest<List<ServerMirror>>("servers");
    }

    [Test]
    public void ShouldThrowExpectedExceptionWhenNetworkCallFails() {
        // Arrange
        var resourceUri = "error";
        SetupFailure<Exception>(resourceUri);

        // Act and Assert
        Assert.ThrowsAsync<Exception>(async () => await ProcessRequest<List<Codec>>(resourceUri));
    }

    private async Task ProcessRequest<T>(string resourceUri) {
        // Arrange
        var requestPayload = new RequestPayload {
            ResourceUri = resourceUri,
            Parameters = new List<Parameter> {
                Parameter.CreateParameter("id", 3, ParameterType.UrlSegment)
            }
        };

        // Act
        var response = await sut.ProcessRequest<T>(requestPayload);

        // Assert
        Assert.That(response, Is.Not.Null);
        mockHttpMessageHandler.VerifyNoOutstandingRequest();
    }

    private void SetupTestData(string testDataFileName, string resourceUri) {
        var testData = File.ReadAllText($"TestData/{testDataFileName}.json");
        mockHttpMessageHandler.When($"http://localhost/{resourceUri}")
                              .Respond("application/json", testData);
    }

    private void SetupFailure<TException>(string resourceUri) where TException : Exception, new() {
        mockHttpMessageHandler.When($"http://localhost/{resourceUri}")
            .Throw(new TException());
    }
}