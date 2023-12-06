using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.EnviromentalReports.Interfaces
{
    public interface IEnviromentalReportsRepository
    {
        public Task AddReports(long userId, IEnumerable<EnviromentalReport> reports);
        public Task<IEnumerable<EnviromentalReport>> GetEnviromentalReportsAsync(long userId ,int? topicId, int pageSize, int page);
    }
}
