using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodhubapi.Models;

[Table("ShoppingCarts")]
public class ShoppingCart
{
  public int FoodMenuId { get; set; }
  public FoodMenu FoodMenu { get; set; }
  public string AppUserId { get; set; }
  public AppUser AppUser { get; set; }

}
