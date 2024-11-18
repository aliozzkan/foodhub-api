using System;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IPortfolioRepository
{
  Task<List<Stock>> GetUserPortfolioAsync(AppUser user);
  Task<Portfolio> CreateAsync(Portfolio portfolio);
  Task<Portfolio?> DeleteAsync(AppUser user, string symbol);
}
