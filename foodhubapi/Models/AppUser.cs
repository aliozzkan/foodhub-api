using System;
using Microsoft.AspNetCore.Identity;

namespace foodhubapi.Models;

public class AppUser : IdentityUser
{
  public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
  public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

}
