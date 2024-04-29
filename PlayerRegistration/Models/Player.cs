using System.Text.Json.Serialization;

namespace PlayerRegistration.Models;

public class Player
{
    public static string Xml = "player_registration";
    public string Id { get; set; }
    public static string XmlId = "id";
    public string Name { get; set; }
    public static string XmlName = "name";
    public string Age { get; set; }
    public static string XmlAge = "age";

    public string Country { get; set; }
    public static string XmlCountry = "country";

    public string Position { get; set; }
    public static string XmlPosition = "position";

    [JsonIgnore]
    public List<Achievement> Achievements { get; set; }
    public static string XmlAchievements = "achievements";
}
