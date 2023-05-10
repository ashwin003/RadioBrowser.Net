using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services.Implementations;

internal class StateService : IStateService {
    private readonly IApiService apiService;

    public StateService(IApiService apiService) {
        this.apiService = apiService;
    }

    public async Task<IEnumerable<State>> FetchAsync(StateSearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "states",
            Parameters = filter.ToParameters()
        };
        return await apiService.ProcessRequest<IEnumerable<State>>(requestPayload, cancellationToken).ConfigureAwait(false);
    }
}