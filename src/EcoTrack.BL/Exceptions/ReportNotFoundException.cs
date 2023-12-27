namespace EcoTrack.BL.Exceptions
{
    public class ReportNotFoundException : Exception
    {
        public ReportNotFoundException(string? message) : base(message)
        {
        }
    }
}
