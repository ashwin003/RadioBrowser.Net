using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services.Implementations;

internal class CodecService : ICodecService {
    private readonly IApiService apiService;

    public CodecService(IApiService apiService) {
        this.apiService = apiService;
    }
    public async Task<IEnumerable<Codec>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "codecs",
            Parameters = filter.ToParameters()
        };
        return await apiService.ProcessRequest<IEnumerable<Codec>>(requestPayload, cancellationToken);
    }
}