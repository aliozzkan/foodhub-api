using System;

namespace foodhubapi.Dtos.Account;

public class NewUserDto
{
  public string Email { get; set; }
  public string UserName { get; set; }
  public string Token { get; set; }
}