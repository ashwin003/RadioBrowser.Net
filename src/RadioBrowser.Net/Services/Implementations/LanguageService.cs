using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services.Implementations;

internal class LanguageService : ILanguageService {

    private readonly IApiService apiService;

    public LanguageService(IApiService apiService) {
        this.apiService = apiService;
    }

    public async Task<IEnumerable<Language>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default) {
        var requestPayload = new RequestPayload {
            ResourceUri = "languages",
            Parameters = filter.ToParameters()
        };
        return await apiService.ProcessRequest<IEnumerable<Language>>(requestPayload, cancellationToken);
    }
}