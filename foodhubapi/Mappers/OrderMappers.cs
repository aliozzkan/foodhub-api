using System;
using foodhubapi.Dtos.Order;
using foodhubapi.Models;

namespace foodhubapi.Mappers;

public class OrderMappers
{
  public static Order ToOrderFromCreateOrderRequestDto(CreateOrderRequestDto createOrderRequestDto)
  {
    return new Order
    {
      AppUserId = createOrderRequestDto.AppUserId,
      Price = createOrderRequestDto.Price,
    };
  }
}
