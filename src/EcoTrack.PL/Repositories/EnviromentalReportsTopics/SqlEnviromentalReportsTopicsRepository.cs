using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReportsTopics.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.PL.Repositories.EnviromentalReportsTopics
{
    public class SqlEnviromentalReportsTopicsRepository : IEnviromentalReportsTopicsRepository
    {
        private readonly EcoTrackDBContext _dbContext;

        public SqlEnviromentalReportsTopicsRepository(EcoTrackDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<EnviromentalReportsTopic>> GetAllAsync()
        {
           return await _dbContext.enviromentalReportsTopics.ToListAsync();
        }

        public async Task AddTopicAsync(EnviromentalReportsTopic topic)
        {
            await _dbContext.AddAsync(topic);
            await _dbContext.SaveChangesAsync();
        }
    }
}
