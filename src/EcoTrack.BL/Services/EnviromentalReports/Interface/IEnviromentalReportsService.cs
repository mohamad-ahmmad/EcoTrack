using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EnviromentalReports.Interface
{
    public interface IEnviromentalReportsService
    {
        public Task<IEnumerable<EnviromentalReportsTopic>> GetAllEnviromentalReportsTopics();
        public Task AddEnviromentalReportsTopics(EnviromentalReportsTopic topic);
    }
}
