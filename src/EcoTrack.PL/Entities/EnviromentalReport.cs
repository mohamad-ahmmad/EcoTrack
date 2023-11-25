namespace EcoTrack.PL.Entities
{
    public class EnviromentalReport
    {
        public long EnviromentalReportId {set; get;}
        public User User { set; get;}
        public long UserId { set; get; }
        public EnviromentalReportsTopic EnviromentalReportsTopic { set; get; }
        public double Value { set; get; }
        public DateTime ReportDate { set; get; } = DateTime.Now;
        public bool IsDeleted { set; get; } = false;

    }
}
