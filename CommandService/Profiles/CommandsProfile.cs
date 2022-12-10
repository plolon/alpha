using AutoMapper;
using CommandService.Dtos;
using CommandService.Models;

namespace CommandService.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // dto -> domain
            CreateMap<CommandCreateDto, Command>();

            // domain -> dto
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<Command, CommandReadDto>();
        }
    }
}