using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.EniromentalReportsSender;
using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReports;

namespace EcoTrack.BL.Services.EnviromentalReports
{
    public class EnviromentalReportsService : IEnviromentalReportsService
    {
        private readonly IEnviromentalReportsRepository _reportsRepo;
        private readonly IEnviromentalReportMessageSender _reportSender;

        public EnviromentalReportsService(
            IEnviromentalReportsRepository reportsRepo,
            IEnviromentalReportMessageSender reportSender)
        {
            _reportsRepo = reportsRepo ?? 
                throw new ArgumentNullException(nameof(reportsRepo));
            _reportSender = reportSender ?? 
                throw new ArgumentNullException(nameof(reportSender));
        }
        public void AddReport(EnviromentalReport report)
        {
            _reportsRepo.AddReport(report);
            _reportSender.SendReport(report);
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
