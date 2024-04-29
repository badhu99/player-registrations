using PlayerRegistration.Models;

namespace PlayerRegistration.Interfaces;

public interface IEventService
{
    public (List<PlayerInfoEvent> playerEvents, List<PlayerAchievementEvent> achievementEvents) CreateEvents(List<Player> players);
    public void Publish<T>(List<T> events, string fileName) where T: BaseEvent;
}
