using System;
using foodhubapi.Data;
using foodhubapi.Dtos.FoodMenu;
using foodhubapi.Interfaces;
using foodhubapi.Mappers;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class FoodMenuRepository : IFoodMenuRepository
{
  private readonly AppDbContext _context;

  public FoodMenuRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<FoodMenu> CreateAsync(CreateFoodMenuRequestDto createDto)
  {
    var foodMenuModel = createDto.ToFoodMenuFromCreateDto();
    await _context.FoodMenus.AddAsync(foodMenuModel);
    await _context.SaveChangesAsync();

    return foodMenuModel;
  }

  public async Task<FoodMenu?> DeleteAsync(int id)
  {
    var foodMenuModel = await _context.FoodMenus.FirstOrDefaultAsync(f => f.Id == id);
    if (foodMenuModel == null)
    {
      return null;
    }

    _context.FoodMenus.Remove(foodMenuModel);
    await _context.SaveChangesAsync();
    return foodMenuModel;
  }

  public async Task<List<FoodMenu>> GetAllAsync()
  {
    var foodMenus = await _context.FoodMenus.Include(foodMenu => foodMenu.Food).Include(foodMenu => foodMenu.Restaurant).Select(foodMenu => new FoodMenu
    {
      Id = foodMenu.Id,
      CategoryName = foodMenu.CategoryName,
      Timing = foodMenu.Timing,
      Price = foodMenu.Price,
      FoodId = foodMenu.FoodId,
      RestaurantId = foodMenu.RestaurantId,
      Food = new Food
      {
        Id = foodMenu.Food.Id,
        Name = foodMenu.Food.Name,
        Description = foodMenu.Food.Description,
        Image = foodMenu.Food.Image,
        RestaurantId = foodMenu.Food.RestaurantId
      },
      Restaurant = new Restaurant
      {
        Id = foodMenu.Restaurant.Id,
        Name = foodMenu.Restaurant.Name,
        Address = foodMenu.Restaurant.Address,
        Image = foodMenu.Restaurant.Image
      }
    }).ToListAsync();
    return foodMenus;
  }

  public async Task<FoodMenu?> GetByIdAsync(int id)
  {
    var foodMenuModel = await _context.FoodMenus.FirstOrDefaultAsync(f => f.Id == id);
    if (foodMenuModel == null)
    {
      return null;
    }
    return foodMenuModel;
  }

  public async Task<FoodMenu?> UpdateAsync(int id, UpdateFoodMenuRequestDto updateDto)
  {
    var existingFoodMenu = await _context.FoodMenus.FirstOrDefaultAsync(f => f.Id == id);
    if (existingFoodMenu == null)
    {
      return null;
    }

    existingFoodMenu.CategoryName = updateDto.CategoryName;
    existingFoodMenu.Price = updateDto.Price;
    existingFoodMenu.Timing = updateDto.Timing;

    await _context.SaveChangesAsync();
    return existingFoodMenu;
  }





}
