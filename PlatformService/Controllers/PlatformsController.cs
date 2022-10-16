using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Persistence.IRepositories;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        // GET: /api/platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> Get()
        {
            var platforms = await _platformRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        // GET: /api/paltforms/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformReadDto>> Get(int id)
        {
            var platform = await _platformRepository.Get(id);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
    }
}