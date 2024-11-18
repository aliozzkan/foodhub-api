using System;

namespace foodhubapi.Dtos.FoodMenu;

public class CreateFoodMenuRequestDto
{
  public string CategoryName { get; set; } = string.Empty;
  public int Timing { get; set; }
  public int Price { get; set; }
  public int FoodId { get; set; }
  public int RestaurantId { get; set; }
}
