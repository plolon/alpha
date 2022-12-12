using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.AsyncDataServices;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Persistence.IRepositories;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _httpClient;
        private readonly IMessageBusClient _messageBusClient;

        public PlatformsController(
            IPlatformRepository platformRepository,
            IMapper mapper,
            ICommandDataClient httpClient,
            IMessageBusClient messageBusClient)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _httpClient = httpClient;
            _messageBusClient = messageBusClient;
        }

        // GET: /api/platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetAllPlatforms()
        {
            var platforms = await _platformRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        // GET: /api/paltforms/1
        [HttpGet("{id}", Name = "GetPlatformById")]
        public async Task<ActionResult<PlatformReadDto>> GetPlatformById(int id)
        {
            var platform = await _platformRepository.Get(id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        //POST: /api/platforms
        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformDto)
        {
            var platform = _mapper.Map<Platform>(platformDto);
            await _platformRepository.Add(platform);
            await _platformRepository.SaveChanges();
            var platformResult = _mapper.Map<PlatformReadDto>(platform);

            // Send Sync Message
            try
            {
                await _httpClient.SendPlatformToCommand(platformResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
            }

            //Send Async Message
            try
            {
                var platformPublishedDto = _mapper.Map<PlatformPublishedDto>(platformResult);
                platformPublishedDto.Event = "Platform_Published";
                _messageBusClient.PublishNewPlatform(platformPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not send asynchronously: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformResult.Id }, platformResult);
        }
    }
}