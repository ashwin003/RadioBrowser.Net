using RadioBrowser.Net.Extensions;
using RadioBrowser.Net.Services.Implementations;
using RadioBrowser.Net.Services;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ServiceExtensions {
        public static IServiceCollection AddRadioBrowserServices(this IServiceCollection services, string userAgent) {
            return services
                .AddSingleton(factory => {
                    var format = "json";
                    var availableServers = new List<string>
                    {
                        $"https://at1.api.radio-browser.info/{format}/",
                        $"https://de1.api.radio-browser.info/{format}/",
                        $"https://nl1.api.radio-browser.info/{format}/"
                    };

                    var selectedServer = availableServers.PickRandom();
                    var restClient = new RestClient(selectedServer).UseNewtonsoftJson();
                    restClient.AddDefaultHeader("User-Agent", userAgent);
                    return restClient;
                })
                .AddTransient<IApiService, ApiService>()
                .AddTransient<ICodecService, CodecService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<ILanguageService, LanguageService>()
                .AddTransient<IServerService, ServerService>()
                .AddTransient<IStateService, StateService>()
                .AddTransient<IStationService, StationService>();
        }
    }
}