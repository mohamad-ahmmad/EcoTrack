using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.EnviromentalThresholds.Interface;
using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalThresholds.Interface;
using EcoTrack.PL.Repositories.Users.Interface;

namespace EcoTrack.BL.Services.EnviromentalThresholds
{
    public class EnviromentalThresholdsService : IEnviromentalThresholdsService
    {
        private readonly IEnviromentalThresholdsRepository _enviromentalThresholdsRepository;
        private readonly IUserRepository _userRepository;

        public EnviromentalThresholdsService(IEnviromentalThresholdsRepository enviromentalThresholdsRepository , IUserRepository userRepository)
        {
            _enviromentalThresholdsRepository = enviromentalThresholdsRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<EnviromentalThreshold>> GetAllEnviromentalThresholdAsync(long userId)
        {
            var threshold = await _enviromentalThresholdsRepository.GetAllAsync(userId);
            if(!await _userRepository.IsFoundByUserIdAsync(userId))
            {
                throw new NotFoundUserException($"user with the id {userId} not found");
            }
            return threshold;
        }

        public async Task<EnviromentalThreshold> AddEnviromentalThresholdAsync(EnviromentalThreshold enviromentalThreshold)
        {
            return await _enviromentalThresholdsRepository.AddEnviromentalThresholdAsync(enviromentalThreshold);
        }

        public async Task DeleteEnviromentalThresholdAsync(long thresholdId)
        {
            bool ifThresholdfound = await _enviromentalThresholdsRepository.DoesThresholdExist(thresholdId);
            if (!ifThresholdfound)
            {
                throw new NotFoundThresholdException($"Threshold with {thresholdId} does not exist!");
            }
            await _enviromentalThresholdsRepository.DeleteEnviromentalthresholdAsync(thresholdId);
        }

        public async Task UpdateThresholdAsync(long thresholdId , double value)
        {
            bool ifThresholdfound = await _enviromentalThresholdsRepository.DoesThresholdExist(thresholdId);
            if (!ifThresholdfound)
            {
                throw new NotFoundThresholdException($"Threshold with {thresholdId} does not exist!");
            }
            await _enviromentalThresholdsRepository.UpdateThresholdAsync(thresholdId, value);
        }
    }
}
