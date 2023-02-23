using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface ILanguageService {
    Task<IEnumerable<Language>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default);
}
