using System;
using foodhubapi.Dtos.FoodMenu;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IFoodMenuRepository
{
  Task<List<FoodMenu>> GetAllAsync();
  Task<FoodMenu?> GetByIdAsync(int id);
  Task<FoodMenu> CreateAsync(CreateFoodMenuRequestDto createDto);
  Task<FoodMenu?> UpdateAsync(int id, UpdateFoodMenuRequestDto updateDto);
  Task<FoodMenu?> DeleteAsync(int id);


}
