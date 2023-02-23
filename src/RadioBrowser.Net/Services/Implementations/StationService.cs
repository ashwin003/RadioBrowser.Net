using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;
using RestSharp;

namespace RadioBrowser.Net.Services.Implementations;

internal class StationService : IStationService {
    private readonly IApiService apiService;

    public StationService(IApiService apiService) {
        this.apiService = apiService;
    }

    public async Task<IEnumerable<Station>> AdvancedSearchAsync(AdvancedStationSearch searchParameters, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "stations/search",
            Parameters = searchParameters.ToParameters(),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchAsync(StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "stations",
            Parameters = filter.ToParameters(),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByCodecAsync(string codec, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var codecParameter = Parameter.CreateParameter("codec", codec, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bycodecexact/{codec}" : "stations/bycodec/{codec}",
            Parameters = filter.ToParameters(codecParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByCountryAsync(string country, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var countryParameter = Parameter.CreateParameter("country", country, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bycountryexact/{country}" : "stations/bycountry/{country}",
            Parameters = filter.ToParameters(countryParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByLanguageAsync(string language, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var languageParameter = Parameter.CreateParameter("language", language, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bylanguageexact/{language}" : "stations/bylanguage/{language}",
            Parameters = filter.ToParameters(languageParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByNameAsync(string name, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var nameParameter = Parameter.CreateParameter("name", name, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bynameexact/{name}" : "stations/byname/{name}",
            Parameters = filter.ToParameters(nameParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByStateAsync(string state, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var stateParameter = Parameter.CreateParameter("state", state, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bystateexact/{state}" : "stations/bystate/{state}",
            Parameters = filter.ToParameters(stateParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<Station>> FetchByTagAsync(string tag, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var tagParameter = Parameter.CreateParameter("tag", tag, ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = isExactMatch ? "stations/bytagexact/{tag}" : "stations/bytag/{tag}",
            Parameters = filter.ToParameters(tagParameter),
        };
        return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
    }

    public async Task<Station?> FetchByUUIDAsync(Guid guid, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "stations/byuuid/{guid}",
            Parameters = new List<Parameter> {
                Parameter.CreateParameter("guid", guid.ToString(), ParameterType.UrlSegment)
            }
        };
        var stations = await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload, cancellationToken);
        return stations.FirstOrDefault();
    }

    public async Task<IEnumerable<StationCheck>> FetchChecksAsync(StationCheckFilter? filter = null, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "checks",
            Parameters = filter.ToParameters()
        };
        return await apiService.ProcessRequest<IEnumerable<StationCheck>>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<StationCheck>> FetchChecksAsync(Guid id, StationCheckFilter? filter = null, CancellationToken cancellationToken = default) {
        var idParameters = Parameter.CreateParameter("id", id.ToString(), ParameterType.UrlSegment);
        var requestPayload = new RequestPayload {
            ResourceUri = "checks/{id}",
            Parameters = filter.ToParameters(idParameters)
        };
        return await apiService.ProcessRequest<IEnumerable<StationCheck>>(requestPayload, cancellationToken);
    }

    public async Task<StationClickResponse> RegisterClick(Guid id, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = id.ToString(),
        };
        return await apiService.ProcessRequest<StationClickResponse>(requestPayload, cancellationToken);
    }

    public async Task<StationVoteResponse> RegisterVote(Guid id, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "vote/{id}",
            Parameters = new List<Parameter> {
                Parameter.CreateParameter("id", id, ParameterType.UrlSegment)
            }
        };
        return await apiService.ProcessRequest<StationVoteResponse>(requestPayload, cancellationToken);
    }
}