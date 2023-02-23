namespace RadioBrowser.Net.Entities;

public sealed class AdvancedStationSearch {
    /// <summary>
    /// OPTIONAL, name of the station
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// OPTIONAL. True: only exact matches, otherwise all matches.
    /// </summary>
    public bool NameExact { get; set; }

    /// <summary>
    /// OPTIONAL, country of the station
    /// </summary>
    public string Country { get; set; } = "";

    /// <summary>
    /// OPTIONAL. True: only exact matches, otherwise all matches.
    /// </summary>
    public bool CountryExact { get; set; }

    /// <summary>
    /// OPTIONAL, 2-digit countrycode of the station (see <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2</see>).
    /// </summary>
    public string CountryCode { get; set; } = "";

    /// <summary>
    /// OPTIONAL, state of the station
    /// </summary>
    public string State { get; set; } = "";

    /// <summary>
    /// OPTIONAL. True: only exact matches, otherwise all matches.
    /// </summary>
    public bool StateExact { get; set; }

    /// <summary>
    /// OPTIONAL, language of the station
    /// </summary>
    public string Language { get; set; } = "";

    /// <summary>
    /// OPTIONAL. True: only exact matches, otherwise all matches.
    /// </summary>
    public bool LanguageExact { get; set; }

    /// <summary>
    /// OPTIONAL, a tag of the station
    /// </summary>
    public string Tag { get; set; } = "";

    /// <summary>
    /// OPTIONAL. True: only exact matches, otherwise all matches.
    /// </summary>
    public bool TagExact { get; set; }

    public IEnumerable<string> TagList { get; set; } = new List<string>();

    /// <summary>
    /// OPTIONAL, codec of the station
    /// </summary>
    public string Codec { get; set; } = "";

    /// <summary>
    /// OPTIONAL, minimum of kbps for bitrate field of stations in result
    /// </summary>
    public int MinimumBitrate { get; set; }

    /// <summary>
    /// OPTIONAL, maximum of kbps for bitrate field of stations in result
    /// </summary>
    public int MaximumBitrate { get; set; } = 1000000;

    /// <summary>
    /// OPTIONAL, name of the attribute the result list will be sorted by
    /// </summary>
    public StationSortOrder Order { get; set; }

    /// <summary>
    /// OPTIONAL, reverse the result list if set to true
    /// </summary>
    public bool Reverse { get; set; }

    /// <summary>
    /// OPTIONAL, starting value of the result list from the database. For example, if you want to do paging on the server side.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// OPTIONAL, number of returned datarows (stations) starting with offset
    /// </summary>
    public int Limit { get; set; } = 100000;

    /// <summary>
    /// do list/not list broken stations
    /// </summary>
    public bool HideBroken { get; set; }
}
