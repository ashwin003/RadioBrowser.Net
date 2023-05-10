using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services.Implementations;

internal class CountryService : ICountryService
{
    private readonly IApiService apiService;

    public CountryService(IApiService apiService)
    {
        this.apiService = apiService;
    }

    public async Task<IEnumerable<Country>> FetchAsync(SearchFilter? filter = null, CancellationToken cancellationToken = default)
    {
        var requestPayload = new RequestPayload
        {
            ResourceUri = "countries",
            Parameters = filter.ToParameters()
        };
        return await apiService.ProcessRequest<IEnumerable<Country>>(requestPayload, cancellationToken).ConfigureAwait(false);
    }
}