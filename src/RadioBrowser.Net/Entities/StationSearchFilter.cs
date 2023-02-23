namespace RadioBrowser.Net.Entities;

public sealed class StationSearchFilter {
    public StationSortOrder Order { get; set; }

    public bool Reverse { get; set; }

    public bool HideBroken { get; set; }

    public int Offset { get; set; }

    public int Limit { get; set; } = 100000;
}
