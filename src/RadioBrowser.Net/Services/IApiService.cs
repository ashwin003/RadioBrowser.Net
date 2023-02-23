using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Services;

internal interface IApiService {
    Task<T> ProcessRequest<T>(RequestPayload requestPayload, CancellationToken cancellationToken = default);
}
