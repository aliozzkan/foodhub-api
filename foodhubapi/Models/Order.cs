using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace foodhubapi.Models;

[Table("Orders")]
public class Order
{
  public int Id { get; set; }
  public string AppUserId { get; set; }
  public AppUser AppUser { get; set; }
  public decimal Price { get; set; }
  public int Status { get; set; } = (int)OrderStatus.Idle;
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
