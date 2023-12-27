using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReport;
using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.EnviromentalReports.Interface;
using EcoTrack.BL.Services.Users.Interfaces;
using EcoTrack.PL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("api/enviroment-reports")]
    public class EnviromentalReportController : ControllerBase
    {
        private readonly IEnviromentalReportsService _enviromentService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public EnviromentalReportController(
            IEnviromentalReportsService enviromentService,
            IUsersService usersService,
            IMapper mapper)
        {
            _enviromentService = enviromentService ?? throw new ArgumentNullException(nameof(enviromentService));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnviromentalReportDto>>> GetAll(
            [FromQuery] int? userId)
        {
            var reports = await _enviromentService.GetAllAsync(userId);
            var list = _mapper.Map<IEnumerable<EnviromentalReportDto>>(reports);
            return Ok(list);
        }

        [HttpGet("{id}", Name ="Get Report")]
        public async Task<ActionResult<EnviromentalReportDto>> GetReport(int id)
        {
            try
            {
                var report = await _enviromentService.GetReportAsync(id);
                return Ok(report);
            } 
            catch(ReportNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EnviromentalReportDto>> AddReport(
            EnviromentalReportForCreationDto report)
        {
            var user = await _usersService.GetUserByIdAsync((int)report.UserId);
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            var reportToAdd = _mapper.Map<EnviromentalReport>(report);
            await _enviromentService.AddReportAsync(reportToAdd);
            var createdReport = _mapper.Map<EnviromentalReportDto>(reportToAdd);

            return CreatedAtRoute("Get Report", new {
                id = createdReport.EnviromentalReportId
            },
            createdReport
            );

        }
    }
}
