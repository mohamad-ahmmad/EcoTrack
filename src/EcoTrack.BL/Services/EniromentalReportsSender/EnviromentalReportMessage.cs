namespace EcoTrack.BL.Services.EniromentalReportsSender
{
    public class EnviromentalReportMessage
    {
        public long EnviromentalReportId { set; get; }
        public long UserId { set; get; }
        public double Value { set; get; }
        public DateTime ReportDate { set; get; } = DateTime.Now;

    }
}
