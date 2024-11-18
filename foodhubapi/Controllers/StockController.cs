using System;
using foodhubapi.Data;
using foodhubapi.Dtos.Stock;
using foodhubapi.Helpers;
using foodhubapi.Interfaces;
using foodhubapi.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IStockRepository _stockRepo;

  public StockController(AppDbContext context, IStockRepository stockRepository)
  {
    _stockRepo = stockRepository;
    _context = context;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<List<StockDto>>> GetAll([FromQuery] QueryObject query)
  {
    var stocks = await _stockRepo.GetAllAsync(query);
    var stockDtos = stocks.Select(s => s.toStockDto()).ToList().ToList();
    return Ok(stockDtos);
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var stock = await _stockRepo.GetByIdAsync(id);
    if (stock == null)
    {
      return NotFound();
    }
    return Ok(stock);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
  {
    var stockModel = stockDto.toStockFromCreateDto();
    await _stockRepo.CreateAsync(stockModel);
    return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
  }


  [HttpPut]
  [Route("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
  {
    var stockModel = await _stockRepo.UpdateAsync(id, updateDto);
    if (stockModel == null)
    {
      return NotFound();
    }

    return Ok(stockModel.toStockDto());
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var stockModel = await _stockRepo.DeleteAsync(id);
    if (stockModel == null)
    {
      return NotFound();
    }

    return NoContent();
  }
}
