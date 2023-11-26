using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReportsTopic;
using EcoTrack.PL.Entities;

namespace EcoTrack.API.Profiles
{
    public class EnviromentalReportsTopicProfile : Profile
    {
        public EnviromentalReportsTopicProfile() 
        {
            CreateMap<EnviromentalReportsTopic, EnviromentalReportsTopicDto>();
            CreateMap<EnviromentalReportsTopicForPostDto, EnviromentalReportsTopic>(); 
        }
    }
}
