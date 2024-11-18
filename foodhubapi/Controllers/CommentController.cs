using System;
using foodhubapi.Dtos.Comment;
using foodhubapi.Extensions;
using foodhubapi.Interfaces;
using foodhubapi.Mappers;
using foodhubapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace foodhubapi.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{

  private readonly ICommentRepository _commentRepo;
  private readonly IStockRepository _stockRepo;
  private readonly UserManager<AppUser> _userManager;
  public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository, UserManager<AppUser> userManager)
  {
    _commentRepo = commentRepository;
    _stockRepo = stockRepository;
    _userManager = userManager;
  }

  [HttpGet]
  public async Task<ActionResult<List<CommentDto>>> GetAll()
  {
    var comments = await _commentRepo.GetAllAsync();
    var commentDtos = comments.Select(c => c.ToCommentDto()).ToList();
    return Ok(commentDtos);
  }

  [HttpGet]
  [Route("{id:int}")]
  public async Task<ActionResult<CommentDto>> GetById(int id)
  {
    var comment = await _commentRepo.GetByIdAsync(id);



    if (comment == null)
    {
      return NotFound();
    }
    return Ok(comment.ToCommentDto());
  }

  [HttpPost("{stockId:int}")]
  public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
  {
    if (!await _stockRepo.StockExists(stockId))
    {
      return BadRequest("Stock does not exist");
    }

    var username = User.GetUsername();
    var appUser = await _userManager.FindByNameAsync(username);
    
    var comment = commentDto.ToCommentFromCreateDto(stockId);
    comment.AppUserId = appUser.Id;
    await _commentRepo.CreateAsync(comment);
    return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
  {
    var comment = await _commentRepo.UpdateAsync(id, updateCommentDto);
    if (comment == null)
    {
      return NotFound();
    }
    return Ok(comment.ToCommentDto());
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    var comment = await _commentRepo.DeleteAsync(id);
    if (comment == null)
    {
      return NotFound();
    }
    return Ok(comment.ToCommentDto());
  }
}
