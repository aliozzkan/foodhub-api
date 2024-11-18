using System;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface ITokenService
{
  string CreateToken(AppUser user);
}
