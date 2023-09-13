using AutoMapper;
using PlatformService.Dto;
using PlatformService.Entities;

namespace PlatformService.Profiles
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<PlatformDto, Platform>().ReverseMap();
        }
    }
}
