using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.EnviromentalReportsTopics.Interface
{
    public interface IEnviromentalReportsTopicsRepository
    {
        public Task<IEnumerable<EnviromentalReportsTopic>> GetAllAsync();
        public Task AddTopicAsync(EnviromentalReportsTopic topic);
    }
}
