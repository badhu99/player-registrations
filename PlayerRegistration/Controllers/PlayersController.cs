using Microsoft.AspNetCore.Mvc;
using PlayerRegistration.Interfaces;
using PlayerRegistration.Models;

namespace PlayerRegistration.Controllers;

[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IBusinessLogicService _businessLogicService;

    public PlayersController(IBusinessLogicService businessLogicService)
    {
        _businessLogicService = businessLogicService;
    }

    [HttpPost]
    public IActionResult Post([FromForm] ReadDataInput body)
    {
        try
        {
            _businessLogicService.Handle(body.File);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
