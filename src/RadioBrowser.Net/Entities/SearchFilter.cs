namespace RadioBrowser.Net.Entities;

public class SearchFilter {
    /// <summary>
    /// Name of the attribute the result list will be sorted by
    /// </summary>
    public SortOrder Order { get; set; }

    /// <summary>
    /// Reverse the result list if set to true
    /// </summary>
    public bool Reverse { get; set; }

    public bool HideBroken { get; set; }

    /// <summary>
    /// Starting value of the result list from the database. For example, if you want to do paging on the server side.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Number of returned datarows (stations) starting with offset
    /// </summary>
    public int Limit { get; set; } = 100000;
}
