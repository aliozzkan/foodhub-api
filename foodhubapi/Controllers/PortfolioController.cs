using System;
using foodhubapi.Extensions;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/portfolio")]
[ApiController]
public class PortfolioController : ControllerBase
{
  private readonly UserManager<AppUser> _userManager;
  private readonly IStockRepository _stockRepo;
  private readonly IPortfolioRepository _portfolioRepo;

  public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepository)
  {
    _userManager = userManager;
    _stockRepo = stockRepository;
    _portfolioRepo = portfolioRepository;
  }

  [HttpGet]
  [Authorize]
  public async Task<IActionResult> GetUserPortfolio()
  {
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);
    var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);
    return Ok(userPortfolio);

  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> AddPortfolio(string symbol)
  {
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);
    var stock = await _stockRepo.GetBySymbolAsync(symbol);
    if (stock == null) return BadRequest("Stock not found");

    var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);

    if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
    {
      return BadRequest("Stock already in portfolio");
    }

    var portfolio = new Portfolio
    {
      AppUserId = appUser.Id,
      StockId = stock.Id
    };

    await _portfolioRepo.CreateAsync(portfolio);

    if (portfolio == null)
    {
      return BadRequest("Failed to add stock to portfolio");
    }

    return Ok(portfolio);
  }

  [HttpDelete]
  [Authorize]
  public async Task<IActionResult> DeletePortfolio(string symbol)
  {
    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);

    var userPortfolio = await _portfolioRepo.GetUserPortfolioAsync(appUser);
    var filtredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();

    if (filtredStock.Count == 0)
    {
      return BadRequest("Stock not found in portfolio");
    }

    await _portfolioRepo.DeleteAsync(appUser, symbol);
    return Ok();
  }



}
