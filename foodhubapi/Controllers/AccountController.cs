using System;
using foodhubapi.Dtos.Account;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Controllers;

[Route("api/account")]
public class AccountController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signInManager;

  public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _signInManager = signInManager;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
  {
    try
    {
      var appUser = new AppUser
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };

      var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

      if (!createUser.Succeeded)
      {
        return BadRequest(createUser.Errors);
      }

      var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
      if (!roleResult.Succeeded)
      {
        return BadRequest(roleResult.Errors);
      }

      return Ok(
        new NewUserDto
        {
          UserName = appUser.UserName,
          Email = appUser.Email,
          Token = _tokenService.CreateToken(appUser),
        }
      );

    }
    catch (Exception e)
    {
      return StatusCode(500, e.Message);
    }


  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
  {
    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);

    if (user == null)
    {
      return Unauthorized("Invalid username");
    }


    var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    if (!result.Succeeded) return Unauthorized("Invalid password");

    return Ok(
      new NewUserDto
      {
        UserName = user.UserName,
        Email = user.Email,
        Token = _tokenService.CreateToken(user),
      }
    );

  }

}