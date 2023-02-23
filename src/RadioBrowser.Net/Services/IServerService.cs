using RadioBrowser.Net.Entities;

namespace RadioBrowser.Net.Services;

public interface IServerService {
    Task<ServerStat> FetchAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<ServerMirror>> FetchMirrorsAsync(CancellationToken cancellationToken = default);
}