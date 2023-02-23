using Newtonsoft.Json;

namespace RadioBrowser.Net.Entities;

public sealed class StationClickResponse {

    public bool OK { get; set; }

    public string Message { get; set; } = "";

    [JsonProperty("stationuuid")]
    public Guid StationId { get; set; }

    [JsonProperty("name")]
    public string StationName { get; set; } = "";

    [JsonProperty("url")]
    public string URL { get; set; } = "";
}
