namespace RadioBrowser.Net.Entities;

public sealed class StationCheckFilter {
    /// <summary>
    /// If set, only list checks after the check with the given check.
    /// </summary>
    public Guid? LastCheckId { get; set; }

    /// <summary>
    /// If >0, it will only return history entries from the last 'seconds' seconds.
    /// </summary>
    public int Seconds { get; set; }

    /// <summary>
    /// Number of returned datarows (checks)
    /// </summary>
    public int Limit { get; set; } = 999999;
}