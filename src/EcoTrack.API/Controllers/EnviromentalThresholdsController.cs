using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalThreshold;
using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.EnviromentalThresholds.Interface;
using EcoTrack.PL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("/api/users/{userId}/EnviromentalThresholds")]
    public class EnviromentalThresholdsController : Controller
    {
        private readonly IEnviromentalThresholdsService _enviromentalThresholdsService;
        private IMapper _mapper;
        private readonly ILogger<EnviromentalThresholdsController> _logger;

        public EnviromentalThresholdsController(IEnviromentalThresholdsService enviromentalThresholdsService, IMapper mapper, ILogger<EnviromentalThresholdsController> logger)
        {
            _enviromentalThresholdsService = enviromentalThresholdsService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EnviromentalThresholdDto>>> GetAll(long userId)
        {
            var userRequestedId = long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);
            if (userId != userRequestedId)
            {
                return Forbid();
            }

            try
            {
                var thresholds = await _enviromentalThresholdsService.GetAllEnviromentalThresholdAsync(userId);
                var thresholdsDto = _mapper.Map<IEnumerable<EnviromentalThresholdDto>>(thresholds);
                return Ok(thresholdsDto);
            }
            catch (NotFoundUserException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while getting environmental thresholds of user with {userId} id");
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EnviromentalThresholdDto>> AddThreshold(EnviromentalThresholdDtoForPost thresholdDto, long userId)
        {
            var userRequestedId = long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);
            if (userId != userRequestedId)
            {
                return Forbid();
            }

            var threshold = _mapper.Map<EnviromentalThreshold>(thresholdDto);
            threshold = await _enviromentalThresholdsService.AddEnviromentalThresholdAsync(threshold);
            var thresholdDtoToReturn = _mapper.Map<EnviromentalThresholdDto>(threshold);
            return Ok(thresholdDtoToReturn);
        }

        [HttpDelete("{thresholdId}")]
        [Authorize]
        public async Task<ActionResult> DeleteThreshold(long thresholdId, long userId)
        {
            var userRequestedId = long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);
            if (userId != userRequestedId)
            {
                return Forbid();
            }

            try
            {
                await _enviromentalThresholdsService.DeleteEnviromentalThresholdAsync(thresholdId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{thresholdId}")]
        [Authorize]
        public async Task<ActionResult> UpdateThreshold(long thresholdId , long userId, EnviromentalThresholdDtoForUpdate thresholdDto)
        {
            var userRequestedId = long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);
            if (userId != userRequestedId)
            {
                return Forbid();
            }

            try
            {
                await _enviromentalThresholdsService.UpdateThresholdAsync(thresholdId , thresholdDto.Value);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
