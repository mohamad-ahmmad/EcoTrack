namespace EcoTrack.API.Dtos.EnviromentalReport
{
    public class EnviromentalReportForCreationDto
    {
        public long UserId { set; get; }
        public double Value { set; get; }
        public string EnviromentalReportsTopic { set; get; } = string.Empty;
    }
}
