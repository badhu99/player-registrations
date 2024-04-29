using PlayerRegistration.Models;

namespace PlayerRegistration.Interfaces;

public interface IBusinessLogicService
{
    public void Handle(IFormFile file);
}
