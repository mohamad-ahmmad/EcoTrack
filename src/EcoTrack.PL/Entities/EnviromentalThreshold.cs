using System.ComponentModel.DataAnnotations.Schema;

namespace EcoTrack.PL.Entities
{
    public class EnviromentalThreshold
    {
        public long EnviromentalThresholdId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long EnviromentalReportsTopicId { get; set; }
        public EnviromentalReportsTopic EnviromentalReportsTopic { get; set; }
        public double Value { get; set; }

    }
}
