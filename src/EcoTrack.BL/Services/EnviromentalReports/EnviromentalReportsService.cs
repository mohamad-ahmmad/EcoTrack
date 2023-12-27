using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReports;

namespace EcoTrack.BL.Services.EnviromentalReports
{
    public class EnviromentalReportsService : IEnviromentalReportsService
    {
        private readonly IEnviromentalReportsRepository _reportsRepo;

        public EnviromentalReportsService(
            IEnviromentalReportsRepository reportsRepo)
        {
            _reportsRepo = reportsRepo ?? 
                throw new ArgumentNullException(nameof(reportsRepo));
        }
        public void AddReport(EnviromentalReport report)
        {
            _reportsRepo.AddReport(report);
        }

        public async Task<IEnumerable<EnviromentalReport>> GetAllAsync(int? userId)
        {
            return await _reportsRepo.GetAllAsync(userId);
        }

        public async Task<EnviromentalReport> GetReportAsync(int id)
        {
            var report = await _reportsRepo.GetReportAsync(id);
            return report ??
                throw new ReportNotFoundException();
        }
    }
}
