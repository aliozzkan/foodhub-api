using System;
using foodhubapi.Dtos.FoodMenu;
using foodhubapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/foodmenu")]
[ApiController]
public class FoodMenuController : ControllerBase
{
  private readonly IFoodMenuRepository _foodMenuRepo;

  public FoodMenuController(IFoodMenuRepository foodMenuRepo)
  {
    _foodMenuRepo = foodMenuRepo;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var foodMenus = await _foodMenuRepo.GetAllAsync();
    return Ok(foodMenus);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var foodMenu = await _foodMenuRepo.GetByIdAsync(id);
    if (foodMenu == null)
    {
      return NotFound();
    }
    return Ok(foodMenu);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateFoodMenuRequestDto foodMenuDto)
  {
    var foodMenuModel = await _foodMenuRepo.CreateAsync(foodMenuDto);
    return CreatedAtAction(nameof(GetById), new { id = foodMenuModel.Id }, foodMenuModel);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFoodMenuRequestDto updateDto)
  {
    var foodMenuModel = await _foodMenuRepo.UpdateAsync(id, updateDto);
    if (foodMenuModel == null)
    {
      return NotFound();
    }
    return Ok(foodMenuModel);
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    var foodMenuModel = await _foodMenuRepo.DeleteAsync(id);
    if (foodMenuModel == null)
    {
      return NotFound();
    }
    return Ok(foodMenuModel);
  }


}
