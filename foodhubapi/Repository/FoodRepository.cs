using System;
using foodhubapi.Data;
using foodhubapi.Dtos.Food;
using foodhubapi.Interfaces;
using foodhubapi.Mappers;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class FoodRepository : IFoodRepository
{
  private readonly AppDbContext _context;

  public FoodRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Food> CreateAsync(CreateFoodRequestDto foodRequestDto)
  {
    var foodModel = foodRequestDto.ToFoodFromCreateDto();
    await _context.Foods.AddAsync(foodModel);
    await _context.SaveChangesAsync();

    return foodModel;
  }

  public async Task<Food?> DeleteAsync(int id)
  {
    var foodModel = await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);
    if (foodModel == null)
    {
      return null;
    }

    _context.Foods.Remove(foodModel);
    await _context.SaveChangesAsync();
    return foodModel;
  }

  public async Task<List<Food>> GetAllAsync()
  {
    var foods = await _context.Foods.ToListAsync();
    return foods;
  }

  public async Task<Food?> GetByIdAsync(int id)
  {
    var foodModel = await _context.Foods.Include(f => f.Restaurant).FirstOrDefaultAsync(f => f.Id == id);
    if (foodModel == null)
    {
      return null;
    }
    return foodModel;
  }

  public async Task<Food?> UpdateAsync(int id, UpdateFoodRequestDto updateFoodRequestDto)
  {
    var existingFood = await _context.Foods.FirstOrDefaultAsync(f => f.Id == id);
    if (existingFood == null)
    {
      return null;
    }

    existingFood.Name = updateFoodRequestDto.Name;
    existingFood.Description = updateFoodRequestDto.Description;
    existingFood.Image = updateFoodRequestDto.Image;
    existingFood.RestaurantId = updateFoodRequestDto.RestaurantId;

    await _context.SaveChangesAsync();
    return existingFood;
  }



}
