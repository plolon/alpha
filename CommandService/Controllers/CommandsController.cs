using AutoMapper;
using CommandService.Dtos;
using CommandService.Models;
using CommandService.Persistence.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public CommandsController(ICommandRepository commandRepository, IPlatformRepository platformRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommandsForPlatform(int platformId)
        {
            System.Console.WriteLine($"--> GetCommandsForPlatform: {platformId}");
            if (!_platformRepository.Exists(platformId))
                return NotFound();
            var commands = await _commandRepository.GetCommandsForPlatform(platformId);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public async Task<ActionResult<CommandReadDto>> GetCommandForPlatform(int platformId, int commandId)
        {
            System.Console.WriteLine($"--> GetCommand: {platformId} {commandId}");
            if (!_platformRepository.Exists(platformId) || !_commandRepository.Exists(commandId))
                return NotFound();
            var command = await _commandRepository.GetCommand(platformId, commandId);
            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(int platformId, CommandCreateDto commandDto)
        {
            System.Console.WriteLine($"--> CreateCommand: {platformId}");
            if (!_platformRepository.Exists(platformId))
                return NotFound();
            var command = _mapper.Map<Command>(commandDto);
            try
            {
                await _commandRepository.CreateCommand(platformId, command);
                await _commandRepository.SaveChanges();
                var result = _mapper.Map<CommandReadDto>(command);

                return CreatedAtRoute(nameof(GetCommandForPlatform),
                new { platformId = platformId, commandId = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}