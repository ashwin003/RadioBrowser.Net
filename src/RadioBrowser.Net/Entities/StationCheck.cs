using Newtonsoft.Json;
using RadioBrowser.Net.Converters;

namespace RadioBrowser.Net.Entities;

public sealed class StationCheck {

    /// <summary>
    /// A globally unique identifier for the station
    /// </summary>
    [JsonProperty("stationuuid", NullValueHandling = NullValueHandling.Ignore)]
    public Guid Id { get; set; }

    /// <summary>
    /// An unique id for this StationCheck
    /// </summary>
    [JsonProperty("changeuuid", NullValueHandling = NullValueHandling.Ignore)]
    public Guid ChangeId { get; set; }

    /// <summary>
    /// DNS Name of the server that did the stream check.
    /// </summary>
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public string Source { get; set; } = "";

    /// <summary>
    /// High level name of the used codec of the stream. May have the format AUDIO or AUDIO/VIDEO.
    /// </summary>
    [JsonProperty("codec", NullValueHandling = NullValueHandling.Ignore)]
    public string Codec { get; set; } = "";

    /// <summary>
    /// Bitrate 1000 bits per second (kBit/s) of the stream. (Audio + Video)
    /// </summary>
    [JsonProperty("bitrate", NullValueHandling = NullValueHandling.Ignore)]
    public int Bitrate { get; set; }

    /// <summary>
    /// Whether or not the stream is an <see href="https://en.wikipedia.org/wiki/HTTP_Live_Streaming">HLS Stream</see>
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("hls", NullValueHandling = NullValueHandling.Ignore)]
    public bool HLS { get; set; }

    /// <summary>
    /// Whether or not the stream is rechable
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("ok", NullValueHandling = NullValueHandling.Ignore)]
    public bool OK { get; set; }

    [JsonProperty("timestamp_iso8601", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Direct stream url that has been resolved from the main stream url. HTTP redirects and playlists have been decoded. If HLS is true then this is still a HLS-playlist.
    /// </summary>
    [JsonProperty("url_cache")]
    public string URLCache { get; set; } = "";

    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("metainfo_overrides_database", NullValueHandling = NullValueHandling.Ignore)]
    public bool MetaInfoOverrides { get; set; }

    /// <summary>
    /// Whether or not the stream has provided extended information and it should be used to override the local database
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("public", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsPublic { get; set; }

    /// <summary>
    /// The name extracted from the stream header.
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = "";

    /// <summary>
    /// The description extracted from the stream header.
    /// </summary>
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; } = "";

    /// <summary>
    /// list of tags. (genres of this stream)
    /// </summary>
    [JsonConverter(typeof(CommaSeparatedConverter))]
    [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// Official countrycodes as in <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2</see>
    /// </summary>
    [JsonProperty("countrycode", NullValueHandling = NullValueHandling.Ignore)]
    public string CountryCode { get; set; } = "";

    /// <summary>
    /// Official country subdivision codes as in <see href="https://en.wikipedia.org/wiki/ISO_3166-2">ISO 3166-2</see>
    /// </summary>
    [JsonProperty("countrysubdivisioncode", NullValueHandling = NullValueHandling.Ignore)]
    public string CountrySubdivisionCode { get; set; } = "";

    /// <summary>
    /// The homepage extracted from the stream header.
    /// </summary>
    [JsonProperty("homepage", NullValueHandling = NullValueHandling.Ignore)]
    public string HomePage { get; set; } = "";

    /// <summary>
    /// The favicon extracted from the stream header.
    /// </summary>
    [JsonProperty("favicon", NullValueHandling = NullValueHandling.Ignore)]
    public string Favicon { get; set; } = "";

    /// <summary>
    /// The loadbalancer extracted from the stream header.
    /// </summary>
    [JsonProperty("loadbalancer", NullValueHandling = NullValueHandling.Ignore)]
    public string LoadBalancer { get; set; } = "";

    /// <summary>
    /// The name of the server software used.
    /// </summary>
    [JsonProperty("server_software", NullValueHandling = NullValueHandling.Ignore)]
    public string ServerSoftware { get; set; } = "";

    /// <summary>
    /// Audio sampling frequency in Hz
    /// </summary>
    [JsonProperty("sampling", NullValueHandling = NullValueHandling.Ignore)]
    public int Sampling { get; set; }

    /// <summary>
    /// Timespan in milliseconds this check needed to be finished.
    /// </summary>
    [JsonProperty("timing_ms", NullValueHandling = NullValueHandling.Ignore)]
    public int Timing { get; set; }

    /// <summary>
    /// Whether or not there was an ssl error while connecting to the stream url.
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("ssl_error")]
    public bool SSLError { get; set; }

}
