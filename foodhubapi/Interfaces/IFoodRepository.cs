using System;
using foodhubapi.Dtos.Food;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IFoodRepository
{
  Task<List<Food>> GetAllAsync();
  Task<Food?> GetByIdAsync(int id);
  Task<Food> CreateAsync(CreateFoodRequestDto createFoodDto);
  Task<Food?> UpdateAsync(int id, UpdateFoodRequestDto updateFoodRequestDto);
  Task<Food?> DeleteAsync(int id);

}
