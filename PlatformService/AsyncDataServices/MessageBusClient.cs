using Microsoft.Extensions.Options;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            configuration = configuration;
            var connectionFactory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQHost"],
                Port = int.Parse(configuration["RabbitMQPost"]),
            };
            try
            {
                _connection = connectionFactory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"--> Could not connect to the Message Bus: {ex.Message}");
            }
        }

        public Task PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            throw new NotImplementedException();
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            System.Console.WriteLine($"--> RabbitMQ connection ShutDown");
        }
    }
}