using System;
using foodhubapi.Dtos.Stock;
using foodhubapi.Helpers;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IStockRepository
{
  Task<List<Stock>> GetAllAsync(QueryObject query);
  Task<Stock?> GetByIdAsync(int id);
  Task<Stock?> GetBySymbolAsync(string symbol);
  Task<Stock> CreateAsync(Stock stock);
  Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
  Task<Stock?> DeleteAsync(int id);
  Task<bool> StockExists(int id);
}