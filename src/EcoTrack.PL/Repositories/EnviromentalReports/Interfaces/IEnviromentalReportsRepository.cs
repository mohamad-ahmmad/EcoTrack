using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.EnviromentalReports.Interfaces
{
    public interface IEnviromentalReportsRepository
    {
        public Task<IEnumerable<EnviromentalReport>> GetEnviromentalReportsAsync(long userId ,int? topicId, int pageSize, int page);
    }
}
