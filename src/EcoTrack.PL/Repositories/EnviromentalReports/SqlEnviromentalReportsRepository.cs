using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReports.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.PL.Repositories.EnviromentalReports
{
    public class SqlEnviromentalReportsRepository : IEnviromentalReportsRepository
    {
        private readonly EcoTrackDBContext _dbContext;
        public SqlEnviromentalReportsRepository(EcoTrackDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task AddReports(long userId, IEnumerable<EnviromentalReport> reports)
        {
            foreach (var report in reports)
            {
                report.UserId = userId;
                await _dbContext
                    .EnviromentalReports
                    .AddAsync(report);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EnviromentalReport>> GetEnviromentalReportsAsync(long userId ,int? topicId ,int pageSize, int page)
        {
            var query = _dbContext.EnviromentalReports.Include(er=>er.EnviromentalReportsTopic);

            if(topicId != null ) 
            {
                query.Where(er=> er.EnviromentalReportsTopicId == topicId);
            }

            return await query
                .Where(er => er.UserId == userId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
