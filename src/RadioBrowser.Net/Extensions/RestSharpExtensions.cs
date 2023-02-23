﻿using RadioBrowser.Net.Models;

namespace RadioBrowser.Net.Extensions;

internal static class RestSharpExtensions
{
    internal static RestSharp.RestRequest ToRestRequest(this RequestPayload requestPayload)
    {
        var restRequest = new RestSharp.RestRequest(requestPayload.ResourceUri, requestPayload.Method);
        foreach (var parameter in requestPayload.Parameters)
        {
            restRequest.AddParameter(parameter);
        }
        return restRequest;
    }
}