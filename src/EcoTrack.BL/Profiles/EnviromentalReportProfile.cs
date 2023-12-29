using AutoMapper;
using EcoTrack.BL.Models;
using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Profiles
{
    public class EnviromentalReportProfile : Profile
    {
        public EnviromentalReportProfile() 
        {
            CreateMap<EnviromentalReport, EnviromentalReportMessage>()
                .ForMember(report => report.Topic, opt => opt.MapFrom(s => s.EnviromentalReportsTopic.Name));
        }
    }
}
