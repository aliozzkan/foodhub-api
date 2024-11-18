using System;
using foodhubapi.Data;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class PortfolioRepository : IPortfolioRepository
{
  private readonly AppDbContext _context;

  public PortfolioRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Portfolio> CreateAsync(Portfolio portfolio)
  {
    await _context.Portfolios.AddAsync(portfolio);
    await _context.SaveChangesAsync();
    return portfolio;
  }

  public async Task<Portfolio?> DeleteAsync(AppUser user, string symbol)
  {
    var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(p => p.AppUserId == user.Id && p.Stock.Symbol.ToLower() == symbol.ToLower());

    if (portfolioModel == null)
    {
      return null;
    }

    _context.Portfolios.Remove(portfolioModel);
    await _context.SaveChangesAsync();
    return portfolioModel;
  }

  public async Task<List<Stock>> GetUserPortfolioAsync(AppUser user)
  {
    return await _context.Portfolios.Where(p => p.AppUserId == user.Id)
    .Select(p => new Stock
    {
      Id = p.StockId,
      Symbol = p.Stock.Symbol,
      CompanyName = p.Stock.CompanyName,
      Purchase = p.Stock.Purchase,
      LastDiv = p.Stock.LastDiv,
      Industry = p.Stock.Industry,
      MarketCap = p.Stock.MarketCap
    }
    ).ToListAsync();
  }
}
