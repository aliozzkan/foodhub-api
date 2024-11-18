using System;
using foodhubapi.Dtos.Food;
using foodhubapi.Models;

namespace foodhubapi.Mappers;

public static class FoodMappers
{
  public static Food ToFoodFromCreateDto(this CreateFoodRequestDto foodDto)
  {
    return new Food
    {
      Name = foodDto.Name,
      Description = foodDto.Description,
      Image = foodDto.Image,
      RestaurantId = foodDto.RestaurantId
    };
  }
}
