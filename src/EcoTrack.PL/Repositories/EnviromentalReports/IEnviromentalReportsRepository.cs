using EcoTrack.PL.Entities;
using EcoTrack.PL.Interfaces;

namespace EcoTrack.PL.Repositories.EnviromentalReports
{
    public interface IEnviromentalReportsRepository : IUnitOfWork
    {
        Task<IEnumerable<EnviromentalReport>> GetAllAsync(int? userId);
        void AddReport(EnviromentalReport report);
        Task<EnviromentalReport?> GetReportAsync(int reportId);
    }
}
