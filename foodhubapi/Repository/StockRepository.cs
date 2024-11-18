using System;
using foodhubapi.Data;
using foodhubapi.Dtos.Stock;
using foodhubapi.Helpers;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class StockRepository : IStockRepository
{
  private readonly AppDbContext _context;

  public StockRepository(AppDbContext context)
  {
    _context = context;
  }


  public async Task<Stock> CreateAsync(Stock stockModel)
  {
    await _context.Stocks.AddAsync(stockModel);
    await _context.SaveChangesAsync();
    return stockModel;
  }

  public async Task<Stock?> DeleteAsync(int id)
  {
    var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
    if (stockModel == null)
    {
      return null;
    }

    _context.Stocks.Remove(stockModel);
    await _context.SaveChangesAsync();

    return stockModel;
  }

  public async Task<List<Stock>> GetAllAsync(QueryObject query)
  {
    var stocks = _context.Stocks.Include(s => s.Comments).ThenInclude(c => c.AppUser).AsQueryable();

    if (!string.IsNullOrWhiteSpace(query.CompanyName))
    {
      stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
    }

    if (!string.IsNullOrWhiteSpace(query.Symbol))
    {
      stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
    }

    if (!string.IsNullOrWhiteSpace(query.SortBy))
    {
      if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
      {
        stocks = query.IsDescending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
      }
    }

    var skipNumber = (query.PageNumber - 1) * query.PageNumber;
    stocks = stocks.Skip(skipNumber).Take(query.PageSize);

    return await stocks.ToListAsync();
  }

  public async Task<Stock?> GetByIdAsync(int id)
  {
    var stockModel = await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
    if (stockModel == null)
    {
      return null;
    }

    return stockModel;
  }

  public async Task<Stock?> GetBySymbolAsync(string symbol)
  {
    var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
    if (stockModel == null)
    {
      return null;
    }
    return stockModel;
  }

  public async Task<bool> StockExists(int id)
  {
    var stockExists = await _context.Stocks.AnyAsync(s => s.Id == id);
    return stockExists;
  }

  public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
  {
    var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
    if (existingStock == null)
    {
      return null;
    }

    existingStock.Symbol = stockDto.Symbol;
    existingStock.CompanyName = stockDto.CompanyName;
    existingStock.Purchase = stockDto.Purchase;
    existingStock.LastDiv = stockDto.LastDiv;
    existingStock.Industry = stockDto.Industry;
    existingStock.MarketCap = stockDto.MarketCap;

    await _context.SaveChangesAsync();
    return existingStock;
  }

}
