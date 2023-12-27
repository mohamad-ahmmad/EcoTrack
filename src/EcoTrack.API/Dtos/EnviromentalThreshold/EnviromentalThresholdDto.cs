using EcoTrack.API.Dtos.EnviromentalReportsTopic;

namespace EcoTrack.API.Dtos.EnviromentalThreshold
{
    public class EnviromentalThresholdDto
    {
        public long EnviromentalThresholdId { get; set; }
        public long UserId { get; set; }
        public long EnviromentalReportsTopicId { get; set; }
        public EnviromentalReportsTopicDto EnviromentalReportsTopic { get; set; }
        public double Value { get; set; }

    }
}
