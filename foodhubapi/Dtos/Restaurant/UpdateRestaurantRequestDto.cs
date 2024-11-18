using System;

namespace foodhubapi.Dtos.Restaurant;

public class UpdateRestaurantRequestDto
{
  public required string Name { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string Longitude { get; set; } = string.Empty;
  public string Latitude { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;

}
