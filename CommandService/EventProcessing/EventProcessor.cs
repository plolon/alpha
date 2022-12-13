using System.Text.Json;
using AutoMapper;
using CommandService.Dtos;
using CommandService.Models;
using CommandService.Persistence.IRepositories;

namespace CommandService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:
                    //TO DO
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private async Task AddPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IPlatformRepository>();
                var platformPublishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);
                try
                {
                    var platform = _mapper.Map<Platform>(platformPublishedDto);
                    if (await repo.ExternalPlatformExists(platform.ExternalId))
                    {
                        Console.WriteLine("--> Platform already exists");
                        return;
                    }
                    await repo.Add(platform);
                    await repo.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to database {ex.Message}");
                }
            }
        }
    }

    public enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}