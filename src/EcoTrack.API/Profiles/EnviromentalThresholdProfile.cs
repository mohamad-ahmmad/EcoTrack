using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReportsTopic;
using EcoTrack.API.Dtos.EnviromentalThreshold;
using EcoTrack.PL.Entities;

namespace EcoTrack.API.Profiles
{
    public class EnviromentalThresholdProfile : Profile
    {
        public EnviromentalThresholdProfile()
        {
            CreateMap<EnviromentalThreshold, EnviromentalThresholdDto>();
            CreateMap<EnviromentalThresholdDto, EnviromentalThreshold>();
            CreateMap<EnviromentalThresholdDtoForPost, EnviromentalThreshold>();
            CreateMap<EnviromentalReportsTopic, EnviromentalReportsTopicDto>();
        }

    }
}
