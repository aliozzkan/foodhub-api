using System;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IShoppingCartRepository
{
  Task<ShoppingCart> AddToCartAsync(int foodMenuId, string appUserId);
  Task<List<ShoppingCart>> GetShoppingCartAsync(string appUserId);
  Task<ShoppingCart> RemoveFromCartAsync(int foodMenuId, string appUserId);
  Task RemoveShoppingCartAsync(string appUserId);

}
