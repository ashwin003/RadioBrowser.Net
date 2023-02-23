using Newtonsoft.Json;
using RadioBrowser.Net.Converters;

namespace RadioBrowser.Net.Entities;

public sealed class Station {
    /// <summary>
    /// A globally unique identifier for the station
    /// </summary>
    [JsonProperty("stationuuid")]
    public Guid Id { get; set; }

    /// <summary>
    /// A globally unique identifier for the change of the station information
    /// </summary>
    [JsonProperty("changeuuid")]
    public Guid ChangeId { get; set; }

    /// <summary>
    /// The name of the station
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = "";

    /// <summary>
    /// The stream URL provided by the user
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = "";

    /// <summary>
    /// An automatically "resolved" stream URL. Things resolved are playlists (M3U/PLS/ASX...), HTTP redirects (Code 301/302). This link is especially usefull if you use this API from a platform that is not able to do a resolve on its own (e.g. JavaScript in browser) or you just don't want to invest the time in decoding playlists yourself. 
    /// </summary>
    [JsonProperty("url_resolved")]
    public string ResolvedUrl { get; set; } = "";

    /// <summary>
    /// URL to the homepage of the stream, so you can direct the user to a page with more information about the stream.
    /// </summary>
    [JsonProperty("homepage")]
    public string HomePage { get; set; } = "";

    /// <summary>
    /// URL to an icon or picture that represents the stream. (PNG, JPG)
    /// </summary>
    [JsonProperty("favicon")]
    public string Favicon { get; set; } = "";

    /// <summary>
    /// Tags of the stream with more information about it
    /// </summary>
    [JsonConverter(typeof(CommaSeparatedConverter))]
    [JsonProperty("tags")]
    public IEnumerable<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// Full name of the country.
    /// </summary>
    [JsonProperty("country")]
    [Obsolete("DEPRECATED: use countrycode instead")]
    public string Country { get; set; } = "";

    /// <summary>
    /// Official countrycodes as in <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2</see>
    /// </summary>
    [JsonProperty("countrycode")]
    public string CountryCode { get; set; } = "";

    /// <summary>
    /// Full name of the entity where the station is located inside the country
    /// </summary>
    [JsonProperty("state")]
    public string State { get; set; } = "";

    /// <summary>
    /// Languages that are spoken in this stream.
    /// </summary>
    [JsonConverter(typeof(CommaSeparatedConverter))]
    [JsonProperty("language")]
    public IEnumerable<string> Languages { get; set; } = new List<string>();

    /// <summary>
    /// Languages that are spoken in this stream by code <see href="https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">ISO 639-2/B</see>
    /// </summary>
    [JsonConverter(typeof(CommaSeparatedConverter))]
    [JsonProperty("languagecodes")]
    public IEnumerable<string> LanguageCodes { get; set; } = new List<string>();

    /// <summary>
    /// Number of votes for this station. This number is by server and only ever increases. It will never be reset to 0.
    /// </summary>
    [JsonProperty("votes")]
    public int Votes { get; set; }

    /// <summary>
    /// Last time when the stream information was changed in the database
    /// </summary>
    [JsonProperty("lastchangetime_iso8601")]
    public DateTime LastChangeTime { get; set; }

    /// <summary>
    /// The codec of this stream recorded at the last check.
    /// </summary>
    [JsonProperty("codec")]
    public string Codec { get; set; } = "";

    /// <summary>
    /// The bitrate of this stream recorded at the last check.
    /// </summary>
    [JsonProperty("bitrate")]
    public int Bitrate { get; set; }

    /// <summary>
    /// Mark if this stream is using HLS distribution or non-HLS.
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("hls")]
    public bool HLS { get; set; }

    /// <summary>
    /// The current online/offline state of this stream. This is a value calculated from multiple measure points in the internet. The test servers are located in different countries. It is a majority vote. 
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("lastcheckok")]
    public bool LastCheckOK { get; set; }

    /// <summary>
    /// The last time when any radio-browser server checked the online state of this stream
    /// </summary>
    [JsonProperty("lastchecktime_iso8601")]
    public DateTime LastCheckTime { get; set; }

    /// <summary>
    /// The last time when the stream was checked for the online status with a positive result
    /// </summary>
    [JsonProperty("lastcheckoktime_iso8601")]
    public DateTime LastCheckOKTime { get; set; }

    /// <summary>
    /// The last time when this server checked the online state and the metadata of this stream
    /// </summary>
    [JsonProperty("lastlocalchecktime_iso8601")]
    public DateTime? LastLocalCheckTime { get; set; }

    /// <summary>
    /// The time of the last click recorded for this stream
    /// </summary>
    [JsonProperty("clicktimestamp_iso8601")]
    public DateTime ClickTimestamp { get; set; }

    /// <summary>
    /// Clicks within the last 24 hours
    /// </summary>
    [JsonProperty("clickcount")]
    public int ClickCount { get; set; }

    /// <summary>
    /// The difference of the clickcounts within the last 2 days. Posivite values mean an increase, negative a decrease of clicks.
    /// </summary>
    [JsonProperty("clicktrend")]
    public int ClickTrend { get; set; }

    /// <summary>
    /// Whether or not there was an ssl error while connecting to the stream url.
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("ssl_error")]
    public bool SSLError { get; set; }

    /// <summary>
    /// Is true, if the stream owner does provide extended information as HTTP headers which override the information in the database.
    /// </summary>
    [JsonConverter(typeof(BoolConverter))]
    [JsonProperty("has_extended_info")]
    public bool HasExtendedInfo { get; set; }
}