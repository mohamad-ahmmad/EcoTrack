using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReportsTopic;
using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.PL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("/api/EnviromentalReportsTopic")]
    public class EnviromentalReportsTopicsController : Controller
    {
        private readonly IEnviromentalReportsService _envService;
        private readonly IMapper _mapper;   

        public EnviromentalReportsTopicsController(IEnviromentalReportsService envService, IMapper mapper) 
        {
            _envService = envService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnviromentalReportsTopicDto>>> GetAll() 
        {
            var topics = await _envService.GetAllEnviromentalReportsTopics();
            var topicsDto = _mapper.Map<IEnumerable<EnviromentalReportsTopicDto>>(topics);
            return Ok(topicsDto);
        }

        [HttpPost]
        public async Task<ActionResult<EnviromentalReportsTopicDto>> AddTopic(EnviromentalReportsTopicForPostDto topicDto)
        {
            var topic = _mapper.Map<EnviromentalReportsTopic>(topicDto);
            await _envService.AddEnviromentalReportsTopics(topic);
            var topicDtoToReturn = _mapper.Map<EnviromentalReportsTopicDto>(topic);
            return Ok(topicDtoToReturn);
        }

    }
}
