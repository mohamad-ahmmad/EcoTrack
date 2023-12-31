﻿using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReports;
using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.Users.Interfaces;
using EcoTrack.PL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.API.Controllers
{
    [ApiController]
    [Route("/api/users/{userId}/enviromentalreports")]
    public class EnviromentalReportsController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly ILogger<EnviromentalReportsController> _logger;

        public EnviromentalReportsController(IUsersService usersService,
                                                IMapper mapper,
                                                ILogger<EnviromentalReportsController> logger) 
        {
            _usersService = usersService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnviromentalReportDto>>> GetAll
            (
                long userId,
                int? topicId,
                int pageSize=20,
                int page =1
            )
        {
            try
            {
                var users = await _usersService.GetEnviromentalReportsAsync(userId, topicId, pageSize, page);
                var usersDtos = _mapper.Map<IEnumerable<EnviromentalReportDto>>(users);
                return Ok(usersDtos);
            }catch(NotFoundUserException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"Error listing enviromental reports to user with {userId} id.");
                return StatusCode(500, "Server internal error");
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UploadReport(long userId ,IEnumerable<EnviromentalReportForPostDto> reportsDto)
        {
            var userRequestedId = long.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("nameidentifier"))!.Value);
            
            if (userId != userRequestedId)
            {
                return Forbid();
            }
            
            var reports = _mapper.Map<IEnumerable<EnviromentalReport>>(reportsDto);
            await _usersService.UploadReportAsync(userId ,reports);
            return NoContent();
        }
        
    }
}
