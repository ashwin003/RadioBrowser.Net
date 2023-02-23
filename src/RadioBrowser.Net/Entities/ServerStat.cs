using Newtonsoft.Json;

namespace RadioBrowser.Net.Entities;

public sealed class ServerStat {

    [JsonProperty("supported_version")]
    public string SupportedVersion { get; set; } = "";

    [JsonProperty("software_version")]
    public string SoftwareVersion { get; set; } = "";

    public string Status { get; set; } = "";

    public int Stations { get; set; }

    [JsonProperty("stations_broken")]
    public int BrokenStations { get; set; }

    public int Tags { get; set; }

    [JsonProperty("clicks_last_hour")]
    public int ClicksLastHour { get; set; }

    [JsonProperty("clicks_last_day")]
    public int ClicksLastDay { get; set; }

    public int Languages { get; set; }

    public int Countries { get; set; }
}