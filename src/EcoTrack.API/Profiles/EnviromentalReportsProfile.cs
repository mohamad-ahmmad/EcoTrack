using AutoMapper;
using EcoTrack.API.Dtos.EnviromentalReports;
using EcoTrack.PL.Entities;

namespace EcoTrack.API.Profiles
{
    public class EnviromentalReportsProfile : Profile
    {
        public EnviromentalReportsProfile() 
        {
            CreateMap< EnviromentalReportDto, EnviromentalReport>();
            CreateMap<EnviromentalReport, EnviromentalReportDto>();
        }
    }
}
