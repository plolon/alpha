using AutoMapper;
using CommandService.Dtos;
using CommandService.Persistence.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _platformRepository;
        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _mapper = mapper;
            _platformRepository = platformRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetAllPlatforms()
        {
            var platforms = await _platformRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpPost]
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok(new { data = "Inbound test of Platforms Controller" });
        }
    }
}