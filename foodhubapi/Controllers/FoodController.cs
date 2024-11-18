using System;
using foodhubapi.Dtos.Food;
using foodhubapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/food")]
[ApiController]
public class FoodController : ControllerBase
{
  private readonly IFoodRepository _foodRepo;

  public FoodController(IFoodRepository foodRepository)
  {
    _foodRepo = foodRepository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var foods = await _foodRepo.GetAllAsync();
    return Ok(foods);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var food = await _foodRepo.GetByIdAsync(id);
    if (food == null)
    {
      return NotFound();
    }
    return Ok(food);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateFoodRequestDto foodDto)
  {
    var foodModel = await _foodRepo.CreateAsync(foodDto);
    return CreatedAtAction(nameof(GetById), new { id = foodModel.Id }, foodModel);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFoodRequestDto updateDto)
  {
    var foodModel = await _foodRepo.UpdateAsync(id, updateDto);
    if (foodModel == null)
    {
      return NotFound();
    }
    return Ok(foodModel);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    var foodModel = await _foodRepo.DeleteAsync(id);
    if (foodModel == null)
    {
      return NotFound();
    }
    return Ok(foodModel);
  }
}
