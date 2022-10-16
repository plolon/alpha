using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Persistence.IRepositories;

namespace PlatformService.Controllers
{
    [ApiController]
    public class PlatformsController :ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        // GET: /api/platforms
        public async Task<IEnumerable<PlatformReadDto>> Get()
        {
            var platforms = await _platformRepository.GetAll();
            return _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
        }
    }
}