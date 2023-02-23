using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface ITagService {
    Task<IEnumerable<Tag>> FetchTagsAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default);
}
