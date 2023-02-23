using RadioBrowser.Net.Entities;
using RestSharp;

namespace RadioBrowser.Net.Extensions;

internal static class AdvancedStationSearchExtension {
    internal static IEnumerable<Parameter> ToParameters(this AdvancedStationSearch? searchParameters) {
        if (searchParameters is null) return Enumerable.Empty<Parameter>();

        var parameters = new List<Parameter>();

        if (!string.IsNullOrWhiteSpace(searchParameters.Name)) parameters.Add(Parameter.CreateParameter("name", searchParameters.Name, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("nameExact", searchParameters.NameExact, ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.Country)) parameters.Add(Parameter.CreateParameter("country", searchParameters.Country, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("countryExact", searchParameters.CountryExact, ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.CountryCode)) parameters.Add(Parameter.CreateParameter("countrycode", searchParameters.CountryCode, ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.State)) parameters.Add(Parameter.CreateParameter("state", searchParameters.State, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("stateExact", searchParameters.StateExact, ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.Language)) parameters.Add(Parameter.CreateParameter("language", searchParameters.Language, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("languageExact", searchParameters.LanguageExact, ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.Tag)) parameters.Add(Parameter.CreateParameter("tag", searchParameters.Tag, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("tagExact", searchParameters.TagExact, ParameterType.QueryString));

        if (searchParameters.TagList.Any()) parameters.Add(Parameter.CreateParameter("tagList", string.Join(",", searchParameters.TagList), ParameterType.QueryString));

        if (!string.IsNullOrWhiteSpace(searchParameters.Codec)) parameters.Add(Parameter.CreateParameter("codec", searchParameters.Codec, ParameterType.QueryString));

        parameters.Add(Parameter.CreateParameter("bitrateMin", searchParameters.MinimumBitrate, ParameterType.QueryString));
        parameters.Add(Parameter.CreateParameter("bitrateMax", searchParameters.MaximumBitrate, ParameterType.QueryString));

        parameters.Add(Parameter.CreateParameter("order", searchParameters.Order.ToString().ToLower(), ParameterType.QueryString));

        parameters.Add(Parameter.CreateParameter("reverse", searchParameters.Reverse, ParameterType.QueryString));

        if (searchParameters.Offset >= 0) parameters.Add(Parameter.CreateParameter("offset", searchParameters.Offset, ParameterType.QueryString));
        if (searchParameters.Limit >= 0) parameters.Add(Parameter.CreateParameter("limit", searchParameters.Limit, ParameterType.QueryString));

        parameters.Add(Parameter.CreateParameter("hidebroken", searchParameters.HideBroken, ParameterType.QueryString));

        return parameters;
    }
}