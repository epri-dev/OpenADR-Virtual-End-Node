namespace Oadr.Library.Profile2B
{
    public class ReportName
    {
        public static ReportName HistoryUsage = new ReportName("HISTORY_USAGE");
        public static ReportName HistoryGreenButton = new ReportName("HISTORY_GREENBUTTON");
        public static ReportName TelemetryUsage = new ReportName("TELEMETRY_USAGE");
        public static ReportName TelemetryStatus = new ReportName("TELEMETRY_STATUS");

        public string Name { get; }

        public string MetaDataName => $"METADATA_{Name}";

        public ReportName(string name)
        {
            Name = name;
        }
    }
}
