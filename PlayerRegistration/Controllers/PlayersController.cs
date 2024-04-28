using Microsoft.AspNetCore.Mvc;
using PlayerRegistration.Interfaces;

namespace PlayerRegistration.Controllers;

[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IReaderService _readerService;
    public PlayersController(IReaderService readerService)
    {
        _readerService = readerService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_readerService.Test());
    }

    public IActionResult Post()
    {
        var players = new List<PlayerRegistration>();

        using (var stream = file.OpenReadStream())
        {
            var doc = XDocument.Load(stream);

            foreach (var player in doc.Descendants("player_registration"))
            {
                var playerData = new PlayerRegistration
                {
                    Id = (string)player.Element("id"),
                    Name = (string)player.Element("name"),
                    Age = (string)player.Element("age"),
                    Country = (string)player.Element("country"),
                    Position = (string)player.Element("position"),
                    Achievements = player.Element("achievements").Elements("achievement").Select(a => new Achievement
                    {
                        Year = (string)a.Attribute("year"),
                        Title = (string)a
                    }).ToList()
                };

                players.Add(playerData);
            }
        }

        return players;
    }
}
