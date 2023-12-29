namespace Report_Processor_Service.Models
{
    public class EnviromentalReportMessage
    {
        public long EnviromentalReportId { set; get; }
        public long UserId { set; get; }
        public string Topic { set; get; } = string.Empty;
        public double Value { set; get; }
        public DateTime ReportDate { set; get; } = DateTime.Now;

    }
}
