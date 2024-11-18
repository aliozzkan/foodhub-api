using System;
using foodhubapi.Dtos.Restaurant;
using foodhubapi.Models;

namespace foodhubapi.Mappers;

public static class RestaurantMappers
{
  public static Restaurant ToRestaurantFromCreateDto(this CreateRestaurantRequestDto restaurantDto)
  {
    return new Restaurant
    {
      Name = restaurantDto.Name,
      Address = restaurantDto.Address,
      City = restaurantDto.City,
      Longitude = restaurantDto.Longitude,
      Latitude = restaurantDto.Latitude,
      Image = restaurantDto.Image
    };
  }

}
