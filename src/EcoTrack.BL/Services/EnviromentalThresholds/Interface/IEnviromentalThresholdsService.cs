using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.EnviromentalThresholds.Interface
{
    public interface IEnviromentalThresholdsService
    {
        public Task<IEnumerable<EnviromentalThreshold>> GetAllEnviromentalThresholdAsync(long userId);
        public Task<EnviromentalThreshold> AddEnviromentalThresholdAsync(EnviromentalThreshold enviromentalThreshold);
        public Task DeleteEnviromentalThresholdAsync(long thresholdId);
        public Task UpdateThresholdAsync(long thresholdId, double value);
    }
}
