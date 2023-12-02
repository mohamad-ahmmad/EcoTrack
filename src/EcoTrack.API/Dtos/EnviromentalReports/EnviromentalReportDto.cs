using EcoTrack.API.Dtos.EnviromentalReportsTopic;


namespace EcoTrack.API.Dtos.EnviromentalReports
{
    public class EnviromentalReportDto
    {
        public long EnviromentalReportId { set; get; }
        public long UserId { set; get; }
        public EnviromentalReportsTopicDto EnviromentalReportsTopic { set; get; }
        public double Value { set; get; }
        public DateTime ReportDate { set; get; }
    }
}
