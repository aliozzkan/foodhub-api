using System;
using foodhubapi.Data;
using foodhubapi.Dtos.Restaurant;
using foodhubapi.Interfaces;
using foodhubapi.Mappers;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class RestaurantRepository : IRestaurantRepository
{
  private readonly AppDbContext _context;

  public RestaurantRepository(AppDbContext context)
  {
    _context = context;
  }
  public async Task<Restaurant> CreateAsync(CreateRestaurantRequestDto createRestaurantDto)
  {
    var restaurantModel = createRestaurantDto.ToRestaurantFromCreateDto();
    await _context.Restaurants.AddAsync(restaurantModel);
    await _context.SaveChangesAsync();

    return restaurantModel;
  }

  public async Task<Restaurant?> DeleteAsync(int id)
  {
    var restaurantModel = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
    if (restaurantModel == null)
    {
      return null;
    }

    _context.Restaurants.Remove(restaurantModel);
    await _context.SaveChangesAsync();
    return restaurantModel;
  }

  public async Task<List<Restaurant>> GetAllAsync()
  {
    var restaurants = await _context.Restaurants.ToListAsync();
    return restaurants;
  }

  public async Task<Restaurant?> GetByIdAsync(int id)
  {
    var restaurantModel = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
    if (restaurantModel == null)
    {
      return null;
    }
    return restaurantModel;
  }

  public async Task<Restaurant?> UpdateAsync(int id, UpdateRestaurantRequestDto updateRestaurantRequestDto)
  {
    var existingRestaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
    if (existingRestaurant == null)
    {
      return null;
    }

    existingRestaurant.Name = updateRestaurantRequestDto.Name;
    existingRestaurant.Address = updateRestaurantRequestDto.Address;
    existingRestaurant.City = updateRestaurantRequestDto.City;
    existingRestaurant.Latitude = updateRestaurantRequestDto.Latitude;
    existingRestaurant.Longitude = updateRestaurantRequestDto.Longitude;
    existingRestaurant.Image = updateRestaurantRequestDto.Image;

    await _context.SaveChangesAsync();
    return existingRestaurant;

  }
}
