using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface IStationService {
    Task<IEnumerable<Station>> AdvancedSearchAsync(AdvancedStationSearch searchParameters, CancellationToken cancellationToken = default);

    Task<Station?> FetchByUUIDAsync(Guid guid, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByNameAsync(string name, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByCodecAsync(string codec, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByCountryAsync(string country, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByStateAsync(string state, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByLanguageAsync(string language, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchByTagAsync(string tag, bool isExactMatch, StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<Station>> FetchAsync(StationSearchFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<StationCheck>> FetchChecksAsync(StationCheckFilter? filter = null, CancellationToken cancellationToken = default);

    Task<IEnumerable<StationCheck>> FetchChecksAsync(Guid id, StationCheckFilter? filter = null, CancellationToken cancellationToken = default);

    Task<StationClickResponse> RegisterClick(Guid id, CancellationToken cancellationToken = default);

    Task<StationVoteResponse> RegisterVote(Guid id, CancellationToken cancellationToken = default);
}