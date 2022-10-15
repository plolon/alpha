using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformsProfile :Profile
    {
        public PlatformsProfile()
        {
            // dto -> domain
            CreateMap<PlatformCreateDto, Platform>();

            // domain -> dto
            CreateMap<Platform, PlatformReadDto>();
        }
    }
}