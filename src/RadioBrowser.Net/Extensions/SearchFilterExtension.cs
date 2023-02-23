using RadioBrowser.Net.Entities;
using RestSharp;

namespace RadioBrowser.Net.Extensions;

internal static class SearchFilterExtension {

    internal static IEnumerable<Parameter> ToParameters(this SearchFilter? filter) {
        if (filter is null) return Enumerable.Empty<Parameter>();

        return new List<Parameter> {
                Parameter.CreateParameter("order", filter.Order.ToString().ToLower(), ParameterType.QueryString),

                Parameter.CreateParameter("reverse", filter.Reverse, ParameterType.QueryString),

                Parameter.CreateParameter("hidebroken", filter.HideBroken, ParameterType.QueryString),

                Parameter.CreateParameter("offset", filter.Offset, ParameterType.QueryString),
                Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString)
            };
    }

    internal static IEnumerable<Parameter> ToParameters(this StateSearchFilter? filter) {
        if (filter is null) return Enumerable.Empty<Parameter>();

        var parameters = new List<Parameter> {
                Parameter.CreateParameter("order", filter.Order.ToString().ToLower(), ParameterType.QueryString),

                Parameter.CreateParameter("reverse", filter.Reverse, ParameterType.QueryString),

                Parameter.CreateParameter("hidebroken", filter.HideBroken, ParameterType.QueryString),

                Parameter.CreateParameter("offset", filter.Offset, ParameterType.QueryString),
                Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString)
            };
        if (!string.IsNullOrWhiteSpace(filter.Country)) parameters.Add(Parameter.CreateParameter("country", filter.Country, ParameterType.QueryString));
        return parameters;
    }

    internal static IEnumerable<Parameter> ToParameters(this StationSearchFilter? filter, Parameter? urlSegmentparameter = null) {
        if (filter is null) return Enumerable.Empty<Parameter>();

        var parameters = new List<Parameter>();
        if (urlSegmentparameter is not null) parameters.Add(urlSegmentparameter);
        parameters.AddRange(new List<Parameter>{
                Parameter.CreateParameter("order", filter.Order.ToString().ToLower(), ParameterType.QueryString),

                Parameter.CreateParameter("reverse", filter.Reverse, ParameterType.QueryString),

                Parameter.CreateParameter("hidebroken", filter.HideBroken, ParameterType.QueryString),

                Parameter.CreateParameter("offset", filter.Offset, ParameterType.QueryString),
                Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString)
            });
        return parameters;
    }
}