using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RadioBrowser.Net.Services;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(service => {
    service.AddRadioBrowserServices("SampleApp/1.0.0");
});
var host = builder.Build();
using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var countryService = serviceProvider.GetRequiredService<ICountryService>();
var countries = await countryService.FetchAsync();
foreach (var country in countries) {
    Console.WriteLine(country.Name);
}
Console.ReadKey();