using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services.Implementations;

internal class ServerService : IServerService {
    private readonly IApiService apiService;

    public ServerService(IApiService apiService) {
        this.apiService = apiService;
    }
    public async Task<ServerStat> FetchAsync(CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "stats"
        };
        return await apiService.ProcessRequest<ServerStat>(requestPayload, cancellationToken);
    }

    public async Task<IEnumerable<ServerMirror>> FetchMirrorsAsync(CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "servers"
        };
        return await apiService.ProcessRequest<IEnumerable<ServerMirror>>(requestPayload, cancellationToken);
    }
}
