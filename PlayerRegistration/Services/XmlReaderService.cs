using System.Xml.Linq;
using PlayerRegistration.Interfaces;
using PlayerRegistration.Models;

namespace PlayerRegistration.Services;
public class XmlReaderService : IReaderService
{
    public XmlReaderService() { }

    public List<Player> Read(IFormFile formFile)
    {
        var players = new List<Player>();
        using var stream = formFile.OpenReadStream();
        var doc = XDocument.Load(stream);

        foreach (var player in doc.Descendants(Player.Xml))
        {
            Player playerData = new()
            {
                Id = player.Element(Player.XmlId).Value ?? "",
                Name = player.Element(Player.XmlName).Value,
                Age = player.Element(Player.XmlAge).Value,
                Country = player.Element(Player.XmlCountry).Value,
                Position = player.Element(Player.XmlPosition).Value,
                Achievements = player.Element(Player.XmlAchievements).Elements(Achievement.Xml).Select(a => new Achievement
                {
                    Year = a.Attribute(Achievement.XmlYear)?.Value,
                    Title = a.Value
                }).ToList()
            };

            players.Add(playerData);
        }

        return players;
    }
}
