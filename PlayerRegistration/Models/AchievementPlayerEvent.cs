namespace PlayerRegistration.Models;

public class PlayerAchievementEvent:BaseEvent
{
    public string PlayerId { get; set; }
    public List<Achievement> Achievements { get; set; }
}