using Newtonsoft.Json;

namespace RadioBrowser.Net.Entities {
    public sealed class StationClick {
        [JsonProperty("clickuuid")]
        public Guid Id { get; set; }

        [JsonProperty("stationuuid")]
        public Guid StationId { get; set; }

        [JsonProperty("clicktimestamp_iso8601")]
        public DateTime ClickTimestamp { get; set; }
    }
}
