using System;

namespace foodhubapi.Dtos.FoodMenu;

public class UpdateFoodMenuRequestDto
{
  public string CategoryName { get; set; } = string.Empty;
  public int Timing { get; set; }
  public int Price { get; set; }
}
