using System;

namespace foodhubapi.Dtos.Order;

public class CreateOrderRequestDto
{
  public string AppUserId { get; set; }
  public decimal Price { get; set; }
}
