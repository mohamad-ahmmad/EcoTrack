using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EnviromentalReports.Interface
{
    public interface IEnviromentalReportsService
    {
        Task<IEnumerable<EnviromentalReport>> GetAllAsync(int? userId);
        void AddReport(EnviromentalReport report);
        Task<EnviromentalReport> GetReportAsync(int id);
    }
}
