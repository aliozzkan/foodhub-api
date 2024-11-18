using System;

namespace foodhubapi.Dtos.Food;

public class UpdateFoodRequestDto
{
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  public int RestaurantId { get; set; }
}
