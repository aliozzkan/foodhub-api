using System;
using foodhubapi.Dtos.Restaurant;
using foodhubapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/restaurant")]
[ApiController]
public class RestaurantController : ControllerBase
{

  private readonly IRestaurantRepository _restaurantRepo;

  public RestaurantController(IRestaurantRepository restaurantRepository)
  {
    _restaurantRepo = restaurantRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var restaurants = await _restaurantRepo.GetAllAsync();
    return Ok(restaurants);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var restaurant = await _restaurantRepo.GetByIdAsync(id);
    if (restaurant == null)
    {
      return NotFound();
    }
    return Ok(restaurant);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateRestaurantRequestDto restaurantDto)
  {
    var restaurantModel = await _restaurantRepo.CreateAsync(restaurantDto);
    return CreatedAtAction(nameof(GetById), new { id = restaurantModel.Id }, restaurantModel);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRestaurantRequestDto updateDto)
  {
    var restaurantModel = await _restaurantRepo.UpdateAsync(id, updateDto);
    if (restaurantModel == null)
    {
      return NotFound();
    }
    return Ok(restaurantModel);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    var restaurantModel = await _restaurantRepo.DeleteAsync(id);
    if (restaurantModel == null)
    {
      return NotFound();
    }
    return Ok(restaurantModel);
  }

}
