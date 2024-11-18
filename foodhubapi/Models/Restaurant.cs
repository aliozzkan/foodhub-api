using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodhubapi.Models;

[Table("Restaurants")]
public class Restaurant
{
  public int Id { get; set; }
  public required string Name { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
  public string Longitude { get; set; } = string.Empty;
  public string Latitude { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  public List<Food> Foods { get; set; } = new List<Food>();
}
