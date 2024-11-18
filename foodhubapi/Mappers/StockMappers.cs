using System;
using foodhubapi.Dtos.Stock;
using foodhubapi.Models;

namespace foodhubapi.Mappers;

public static class StockMappers
{
  public static StockDto toStockDto(this Stock stockModel)
  {
    return new StockDto
    {
      Id = stockModel.Id,
      Symbol = stockModel.Symbol,
      CompanyName = stockModel.CompanyName,
      Purchase = stockModel.Purchase,
      LastDiv = stockModel.LastDiv,
      Industry = stockModel.Industry,
      MarketCap = stockModel.MarketCap,
      Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
    };
  }

  public static Stock toStockFromCreateDto(this CreateStockRequestDto stockDto)
  {
    return new Stock
    {
      Symbol = stockDto.Symbol,
      CompanyName = stockDto.CompanyName,
      Purchase = stockDto.Purchase,
      LastDiv = stockDto.LastDiv,
      Industry = stockDto.Industry,
      MarketCap = stockDto.MarketCap
    };
  }

}
