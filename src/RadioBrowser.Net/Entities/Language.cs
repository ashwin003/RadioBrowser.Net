using Newtonsoft.Json;

namespace RadioBrowser.Net.Entities;

public sealed class Language {
    public string Name { get; set; } = "";

    [JsonProperty("iso_639", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = "";

    public int StationCount { get; set; }
}
