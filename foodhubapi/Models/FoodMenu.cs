using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace foodhubapi.Models;

[Table("FoodMenus")]
public class FoodMenu
{
  public int Id { get; set; }
  public string CategoryName { get; set; } = string.Empty;
  public int Timing { get; set; }
  public int Price { get; set; }
  public int FoodId { get; set; }
  public Food Food { get; set; }
  public int RestaurantId { get; set; }
  public Restaurant Restaurant { get; set; }
  public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
