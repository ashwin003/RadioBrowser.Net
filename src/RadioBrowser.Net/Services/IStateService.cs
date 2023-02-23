using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface IStateService {
    Task<IEnumerable<State>> FetchAsync(StateSearchFilter? filter = null, CancellationToken cancellationToken = default);
}
