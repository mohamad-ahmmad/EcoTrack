namespace EcoTrack.BL.Exceptions
{
    public class ReportNotFoundException : Exception
    {
        public ReportNotFoundException() : base("Report not found")
        {
        }
    }
}
