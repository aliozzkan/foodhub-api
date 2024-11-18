using System;
using foodhubapi.Data;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class ShoppingCartRepository : IShoppingCartRepository
{
  private readonly AppDbContext _context;

  public ShoppingCartRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<ShoppingCart> AddToCartAsync(int foodMenuId, string appUserId)
  {
    var shoppingCart = new ShoppingCart
    {
      FoodMenuId = foodMenuId,
      AppUserId = appUserId
    };

    await _context.ShoppingCarts.AddAsync(shoppingCart);
    await _context.SaveChangesAsync();
    return shoppingCart;
  }

  public async Task<List<ShoppingCart>> GetShoppingCartAsync(string appUserId)
  {
    return await _context.ShoppingCarts.Where(sc => sc.AppUserId == appUserId)
    .Include(s => s.FoodMenu)
    .ThenInclude(f => f.Food).ToListAsync();
  }

  public async Task<ShoppingCart> RemoveFromCartAsync(int foodMenuId, string appUserId)
  {
    var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(sc => sc.FoodMenuId == foodMenuId && sc.AppUserId == appUserId);

    if (shoppingCart == null)
    {
      return null;
    }

    _context.ShoppingCarts.Remove(shoppingCart);
    await _context.SaveChangesAsync();
    return shoppingCart;
  }

  public async Task RemoveShoppingCartAsync(string appUserId)
  {
    _context.ShoppingCarts.RemoveRange(_context.ShoppingCarts.Where(sc => sc.AppUserId == appUserId));
    await _context.SaveChangesAsync();
  }


}
