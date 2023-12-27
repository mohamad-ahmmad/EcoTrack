using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.EnviromentalReports
{
    public interface IEnviromentalReportsRepository
    {
        Task<IEnumerable<EnviromentalReport>> GetAllAsync(int? userId);
        Task AddReportAsync(EnviromentalReport report);
        Task<EnviromentalReport> GetReportAsync(int reportId);
    }
}
