using System;
using System.ComponentModel.DataAnnotations;

namespace foodhubapi.Dtos.Food;

public class CreateFoodRequestDto
{
  [Required]
  public string Name { get; set; } = string.Empty;
  [Required]
  [MaxLength(500)]
  public string Description { get; set; } = string.Empty;
  public string Image { get; set; } = string.Empty;
  [Required]
  [Range(1, int.MaxValue)]
  public int RestaurantId { get; set; }
}
