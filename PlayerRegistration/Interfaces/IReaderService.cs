﻿using PlayerRegistration.Models;

namespace PlayerRegistration.Interfaces;

public interface IReaderService
{
    public List<Player> Read(IFormFile formFile);
}
