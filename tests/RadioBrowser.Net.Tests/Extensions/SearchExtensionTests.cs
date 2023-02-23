using RestSharp;

namespace RadioBrowser.Net.Tests.Extensions {
    public class SearchExtensionTests<TSearchFilter> {
        protected IEnumerable<TestData> testDataList = new List<TestData>();
        protected static Parameter NameParameter(string name) => CreateParameter(nameof(name), name);

        protected static Parameter OrderParameter(string order) => CreateParameter(nameof(order), order);

        protected static Parameter NameExactParameter(bool nameExact = false) => CreateParameter(nameof(nameExact), nameExact);

        protected static Parameter CountryParameter(string country) => CreateParameter(nameof(country), country);

        protected static Parameter CountryExactParameter(bool countryExact = false) => CreateParameter(nameof(countryExact), countryExact);

        protected static Parameter CountryCodeParameter(string countrycode) => CreateParameter(nameof(countrycode), countrycode);

        protected static Parameter TagParameter(string tag) => CreateParameter(nameof(tag), tag);

        protected static Parameter TagListParameter(string tagList) => CreateParameter(nameof(tagList), tagList);

        protected static Parameter CodecParameter(string codec) => CreateParameter(nameof(codec), codec);

        protected static Parameter StateParameter(string state) => CreateParameter(nameof(state), state);

        protected static Parameter LanguageParameter(string language) => CreateParameter(nameof(language), language);

        protected static Parameter LanguageExactParameter(bool languageExact = false) => CreateParameter(nameof(languageExact), languageExact);

        protected static Parameter TagExactParameter(bool tagExact = false) => CreateParameter(nameof(tagExact), tagExact);

        protected static Parameter StateExactParameter(bool stateExact = false) => CreateParameter(nameof(stateExact), stateExact);

        protected static Parameter MinimumBitrateParameter(int bitrateMin = 0) => CreateParameter(nameof(bitrateMin), bitrateMin);

        protected static Parameter MaximumBitrateParameter(int bitrateMax = 1000000) => CreateParameter(nameof(bitrateMax), bitrateMax);

        protected static Parameter ReverseParameter(bool reverse = false) => CreateParameter(nameof(reverse), reverse);

        protected static Parameter OffsetParameter(int offset = 0) => CreateParameter(nameof(offset), offset);

        protected static Parameter LimitParameter(int limit = 100000) => CreateParameter(nameof(limit), limit);

        protected static Parameter SecondsParameter(int seconds = 100000) => CreateParameter(nameof(seconds), seconds);

        protected static Parameter LastCheckUUIDParameter(Guid lastcheckuuid) => CreateParameter(nameof(lastcheckuuid), lastcheckuuid);

        protected static Parameter HideBrokenParameter(bool hidebroken = false) => CreateParameter(nameof(hidebroken), hidebroken);

        private static Parameter CreateParameter(string name, object value) => Parameter.CreateParameter(name, value, ParameterType.QueryString);

        protected record class TestData(TSearchFilter? SearchInput, List<Parameter> ExpectedParameters);
    }
}
