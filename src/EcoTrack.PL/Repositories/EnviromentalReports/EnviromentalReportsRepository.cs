using EcoTrack.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.PL.Repositories.EnviromentalReports
{
    public class EnviromentalReportsRepository : IEnviromentalReportsRepository
    {
        private readonly EcoTrackDBContext _context;

        public EnviromentalReportsRepository(EcoTrackDBContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public void AddReport(EnviromentalReport report)
        {
            _context.EnviromentalReports.Add(report);
        }

        public async Task<IEnumerable<EnviromentalReport>> GetAllAsync(int? userId)
        {
            IQueryable<EnviromentalReport> query = _context.EnviromentalReports;

            if (userId != null)
            {
                query.Where(x => x.UserId == userId);
            }

            return await query.ToListAsync();
        }

        public async Task<EnviromentalReport?> GetReportAsync(int reportId)
        {
            return await _context.EnviromentalReports
                .FirstOrDefaultAsync(x => x.EnviromentalReportId == reportId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
