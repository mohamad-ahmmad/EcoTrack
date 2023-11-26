using System.ComponentModel.DataAnnotations;

namespace EcoTrack.API.Dtos.EnviromentalReportsTopic
{
#nullable disable
    public class EnviromentalReportsTopicForPostDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
