using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EnviromentalReportTopics.Interface
{
    public interface IEnviromentalReportTopicsService
    {
        public Task<IEnumerable<EnviromentalReportsTopic>> GetAllEnviromentalReportsTopics();
        public Task AddEnviromentalReportsTopics(EnviromentalReportsTopic topic);
    }
}
