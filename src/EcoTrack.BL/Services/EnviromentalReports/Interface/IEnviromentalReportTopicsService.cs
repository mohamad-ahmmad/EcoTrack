using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EnviromentalReports.Interface
{
    public interface IEnviromentalReportTopicsService
    {
        public Task<IEnumerable<EnviromentalReportsTopic>> GetAllEnviromentalReportsTopics();
        public Task AddEnviromentalReportsTopics(EnviromentalReportsTopic topic);
    }
}
