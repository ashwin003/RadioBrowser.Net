﻿using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Models;
using RestSharp;

namespace RadioBrowser.Net.Services.Implementations;

internal class ApiService : IApiService
{
    private readonly RestClient restClient;

    public ApiService(RestClient restClient)
    {
        this.restClient = restClient;
    }

    public async Task<T> ProcessRequest<T>(RequestPayload requestPayload, CancellationToken cancellationToken = default)
    {
        var restRequest = requestPayload.ToRestRequest();
        var restResponse = await restClient.ExecuteAsync<T>(restRequest, cancellationToken).ConfigureAwait(false);
        if (restResponse.IsSuccessful && restResponse.Data is not null)
        {
            return restResponse.Data!;
        }
        throw restResponse.ErrorException!;
    }
}