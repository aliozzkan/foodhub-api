using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace foodhubapi.Models;

[Table("Foods")]
public class Food
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  public int RestaurantId { get; set; }
  public Restaurant Restaurant { get; set; }
}
