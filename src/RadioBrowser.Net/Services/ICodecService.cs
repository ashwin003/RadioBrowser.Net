using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface ICodecService {
    Task<IEnumerable<Codec>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default);
}
