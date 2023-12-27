using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalThresholds.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.PL.Repositories.EnviromentalThresholds
{
    public class SqlEnviromentalThresholdRepository : IEnviromentalThresholdsRepository
    {
        private readonly EcoTrackDBContext _dbContext;
        public SqlEnviromentalThresholdRepository(EcoTrackDBContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<IEnumerable<EnviromentalThreshold>> GetAllAsync(long userId)
        {
            return await _dbContext.EnviromentalThresholds.Include(et=>et.EnviromentalReportsTopic).Where(u => u.UserId == userId).ToListAsync();
        }
        public async Task<EnviromentalThreshold> AddEnviromentalThresholdAsync(EnviromentalThreshold threshold)
        {
            await _dbContext.AddAsync(threshold);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.EnviromentalThresholds.Include(en => en.EnviromentalReportsTopic).FirstOrDefaultAsync(er => er.EnviromentalThresholdId == threshold.EnviromentalThresholdId);
        }
        public async Task DeleteEnviromentalthresholdAsync(long thresholdId)
        {
            _dbContext.EnviromentalThresholds.Remove(new EnviromentalThreshold { EnviromentalThresholdId = thresholdId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesThresholdExist(long thresholdId)
        {
            return await _dbContext.EnviromentalThresholds.AnyAsync(t => t.EnviromentalThresholdId == thresholdId);
        }

        public async Task UpdateThresholdAsync(long thresholdId , double value)
        {
            var envThreshold = await _dbContext.EnviromentalThresholds
                .FirstOrDefaultAsync(en => en.EnviromentalThresholdId == thresholdId);
            envThreshold.Value = value;
            await _dbContext.SaveChangesAsync();
        }
    }
}
