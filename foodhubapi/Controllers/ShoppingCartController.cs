using System;
using foodhubapi.Extensions;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/shopping-cart")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
  private readonly IShoppingCartRepository _shoppingCartRepo;
  private readonly UserManager<AppUser> _userManager;


  public ShoppingCartController(IShoppingCartRepository shoppingCartRepo, UserManager<AppUser> userManager)
  {
    _shoppingCartRepo = shoppingCartRepo;
    _userManager = userManager;
  }

  [HttpGet]
  [Authorize]
  public async Task<IActionResult> GetShoppingCart()
  {
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    var shoppingCart = await _shoppingCartRepo.GetShoppingCartAsync(appUser.Id);
    return Ok(shoppingCart);
  }

  [HttpPost("{foodMenuId:int}")]
  [Authorize]
  public async Task<IActionResult> AddToShoppingCart([FromRoute] int foodMenuId)
  {
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    var shoppingCart = await _shoppingCartRepo.AddToCartAsync(foodMenuId, appUser.Id);
    return Ok();
  }


}
