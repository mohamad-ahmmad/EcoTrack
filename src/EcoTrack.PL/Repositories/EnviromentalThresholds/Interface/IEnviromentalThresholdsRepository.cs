using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.EnviromentalThresholds.Interface
{
    public interface IEnviromentalThresholdsRepository
    {
        public Task<IEnumerable<EnviromentalThreshold>> GetAllAsync(long userId);
        public Task<EnviromentalThreshold> AddEnviromentalThresholdAsync(EnviromentalThreshold threshold);
        public Task DeleteEnviromentalthresholdAsync(long thresholdId);
        public Task<bool> DoesThresholdExist(long thresholdId);
        public Task UpdateThresholdAsync(long thresholdId, double value);
    }
}
