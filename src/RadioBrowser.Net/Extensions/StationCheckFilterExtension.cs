using RadioBrowser.Net.Entities;
using RestSharp;

namespace RadioBrowser.Net.Extensions;

internal static class StationCheckFilterExtension {
    internal static IEnumerable<Parameter> ToParameters(this StationCheckFilter? filter, Parameter? urlSegmentParameter = null) {
        if (filter is null) return Enumerable.Empty<Parameter>();
        var parameters = new List<Parameter>();
        if (urlSegmentParameter != null) parameters.Add(urlSegmentParameter);
        if (filter.LastCheckId.HasValue) parameters.Add(Parameter.CreateParameter("lastcheckuuid", filter.LastCheckId.ToString(), ParameterType.QueryString));
        if (filter.Seconds > 0) parameters.Add(Parameter.CreateParameter("seconds", filter.Seconds, ParameterType.QueryString));
        if (filter.Limit > 0) parameters.Add(Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString));
        return parameters;
    }
}