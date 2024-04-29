using PlayerRegistration.Interfaces;

namespace PlayerRegistration.Services;
public class BusinessLogicService : IBusinessLogicService
{
    private readonly IReaderService _readerService;
    private readonly IEventService _eventService;

    public BusinessLogicService(IReaderService readerService,
        IEventService eventService)
    {
        _readerService = readerService;
        _eventService = eventService;
    }

    public void Handle(IFormFile file)
    {
        var playersData = _readerService.Read(file);

        var (playerInfoEvents, playerAchievementEvents) = _eventService.CreateEvents(playersData);

        string fileName = file.FileName;
        _eventService.Publish(playerInfoEvents, fileName);
        _eventService.Publish(playerAchievementEvents, fileName);
    }
}
