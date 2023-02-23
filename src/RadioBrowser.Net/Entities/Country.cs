using Newtonsoft.Json;

namespace RadioBrowser.Net.Entities;

public sealed class Country {
    public string Name { get; set; } = "";

    [JsonProperty("iso_3166_1")]
    public string Code { get; set; } = "";

    public int StationCount { get; set; }

    public string Flag { get => string.Concat(Code.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5))); }
}