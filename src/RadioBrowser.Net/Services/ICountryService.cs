using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface ICountryService {
    Task<IEnumerable<Country>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default);
}