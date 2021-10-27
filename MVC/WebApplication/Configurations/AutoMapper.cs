using AutoMapper;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.Configurations
{
    public class AutoMapperConfigurations : Profile
    {
        public AutoMapperConfigurations()
        {
            CreateMap<PcrTest, PcrTestViewModel>().ReverseMap();
            
            // CreateMap<PcrTest, PcrTestViewModel>()
            //     .ForMember(x => x.ReceptionDateee, y => y.MapFrom(z => z.ReceptionDate))
            //     .ReverseMap()
            //     .ForMember(x => x.ReceptionDate, y => y.MapFrom(z => z.ReceptionDateee));

            // CreateMap<PcrTest, PcrTestViewModel>()
            //     .ForMember(x => x.Code, y => y.MapFrom(z => $"{z.Code}{z.Comment}"));
        }
    }
}