using System;
using foodhubapi.Dtos.Restaurant;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface IRestaurantRepository
{
  Task<List<Restaurant>> GetAllAsync();
  Task<Restaurant?> GetByIdAsync(int id);
  Task<Restaurant> CreateAsync(CreateRestaurantRequestDto createRestaurantDto);
  Task<Restaurant?> UpdateAsync(int id, UpdateRestaurantRequestDto updateRestaurantRequestDto);
  Task<Restaurant?> DeleteAsync(int id);
}
