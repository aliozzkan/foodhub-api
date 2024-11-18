using System;
using foodhubapi.Dtos.FoodMenu;
using foodhubapi.Models;

namespace foodhubapi.Mappers;

public static class FoodMenuMappers
{
  public static FoodMenu ToFoodMenuFromCreateDto(this CreateFoodMenuRequestDto dto)
  {
    return new FoodMenu
    {
      CategoryName = dto.CategoryName,
      Timing = dto.Timing,
      Price = dto.Price,
      FoodId = dto.FoodId,
      RestaurantId = dto.RestaurantId
    };
  }

}
