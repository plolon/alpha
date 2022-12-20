using AutoMapper;
using Grpc.Core;
using PlatformService.Persistence.IRepositories;
using static PlatformService.GrpcPlatform;

namespace PlatformService.SyncDataServices.Grpc
{
    public class GrpcPlatformService : GrpcPlatformBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public GrpcPlatformService(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<PlatformResponse> GetAllPlatforms(GetAllRequest request, ServerCallContext context)
        {
            var response = new PlatformResponse();
            var platforms = await _repository.GetAll();
            platforms.ToList().ForEach(x => response.Platform.Add(_mapper.Map<GrpcPlatformModel>(x)));
            return await Task.FromResult(response);
        }
    }
}