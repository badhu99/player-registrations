using Microsoft.AspNetCore.Mvc;
using PlayerRegistration.Interfaces;
using PlayerRegistration.Models;

namespace PlayerRegistration.Controllers;

[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IBusinessLogicService _businessLogicService;

    public PlayersController(IBusinessLogicService businessLogicService, ILogger<PlayersController> logger)
    {
        _businessLogicService = businessLogicService;
    }

    [HttpPost]
    public IActionResult Post([FromForm] ReadDataInput body)
    {
        try
        {
            if (body.File == null)
                return BadRequest("File is required.");

            _businessLogicService.Handle(body.File);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
