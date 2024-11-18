using System;
using foodhubapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {

  }

  public DbSet<Comment> Comments { get; set; }
  public DbSet<Stock> Stocks { get; set; }
  public DbSet<Portfolio> Portfolios { get; set; }
  public DbSet<Restaurant> Restaurants { get; set; }
  public DbSet<Food> Foods { get; set; }
  public DbSet<FoodMenu> FoodMenus { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<ShoppingCart> ShoppingCarts { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Portfolio>().HasKey(p => new { p.AppUserId, p.StockId });
    modelBuilder.Entity<Portfolio>().HasOne(p => p.AppUser).WithMany(u => u.Portfolios).HasForeignKey(p => p.AppUserId);
    modelBuilder.Entity<Portfolio>().HasOne(p => p.Stock).WithMany(s => s.Portfolios).HasForeignKey(p => p.StockId);

    modelBuilder.Entity<ShoppingCart>().HasKey(sc => new { sc.FoodMenuId, sc.AppUserId });
    modelBuilder.Entity<ShoppingCart>().HasOne(sc => sc.FoodMenu).WithMany(f => f.ShoppingCarts).HasForeignKey(sc => sc.FoodMenuId);
    modelBuilder.Entity<ShoppingCart>().HasOne(sc => sc.AppUser).WithMany(u => u.ShoppingCarts).HasForeignKey(sc => sc.AppUserId);

    List<IdentityRole> roles = new List<IdentityRole>
    {
      new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
      new IdentityRole { Name = "User", NormalizedName = "USER" },
    };
    modelBuilder.Entity<IdentityRole>().HasData(roles);
  }
}