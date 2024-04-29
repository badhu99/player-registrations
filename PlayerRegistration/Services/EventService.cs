using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PlayerRegistration.Interfaces;
using PlayerRegistration.Models;
using PlayerRegistration.Settings;
using RabbitMQ.Client;

namespace PlayerRegistration.Services;

public class EventService : IEventService
{
    private readonly RabbitMQSettings _rabbitMQSettings;
    public EventService(IOptions<RabbitMQSettings> settings)
    {
        _rabbitMQSettings = settings.Value;
    }
    public (List<PlayerInfoEvent> playerEvents, List<PlayerAchievementEvent> achievementEvents) CreateEvents(List<Player> players)
    {
        List<PlayerInfoEvent> playerInfoEvents = new();
        List<PlayerAchievementEvent> playerAchievementEvents = new();

        foreach (var player in players)
        {
            PlayerInfoEvent playerInfoEvent = new()
            {
                EventType = "player_registration",
                Player = new()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age = player.Age,
                    Country = player.Country,
                    Position = player.Position
                },
            };
            playerInfoEvents.Add(playerInfoEvent);

            PlayerAchievementEvent playerAchievementEvent = new()
            {
                EventType = "player_achievements",
                PlayerId = player.Id,
                Achievements = player.Achievements,
            };
            playerAchievementEvents.Add(playerAchievementEvent);
        }

        return (playerInfoEvents, playerAchievementEvents);
    }

    public void Publish<T>(List<T> events, string fileName) where T : BaseEvent
    {
        var factory = new ConnectionFactory()
        {
            HostName = _rabbitMQSettings.Hostname,
            UserName = _rabbitMQSettings.Username,
            Password = _rabbitMQSettings.Password
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        string exchangeName = _rabbitMQSettings.ExchangeName;
        string routingKey = _rabbitMQSettings.RoutingKey;

        channel.ExchangeDeclare(exchange: exchangeName, type: "headers");

        foreach (var eventItem in events)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(eventItem));
            var properties = channel.CreateBasicProperties();
            properties.Headers = new Dictionary<string, object> { { "filename", fileName }, { "event_type", eventItem.EventType } };

            channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: properties, body: body);
        }
    }
}
