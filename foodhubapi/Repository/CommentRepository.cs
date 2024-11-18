using System;
using foodhubapi.Data;
using foodhubapi.Dtos.Comment;
using foodhubapi.Interfaces;
using foodhubapi.Models;
using Microsoft.EntityFrameworkCore;

namespace foodhubapi.Repository;

public class CommentRepository : ICommentRepository
{
  private readonly AppDbContext _context;
  public CommentRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Comment> CreateAsync(Comment commentModel)
  {
    await _context.Comments.AddAsync(commentModel);
    await _context.SaveChangesAsync();
    return commentModel;
  }

  public async Task<Comment?> DeleteAsync(int id)
  {
    var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    if (commentModel == null)
    {
      return null;
    }

    _context.Comments.Remove(commentModel);
    await _context.SaveChangesAsync();
    return commentModel;
  }

  public async Task<List<Comment>> GetAllAsync()
  {
    return await _context.Comments.ToListAsync();
  }

  public async Task<Comment?> GetByIdAsync(int id)
  {
    var commentModel = await _context.Comments.Include(c => c.AppUser).FirstOrDefaultAsync(c => c.Id == id);
    if (commentModel == null)
    {
      return null;
    }
    return commentModel;
  }

  public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateCommentDto)
  {
    var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
    if (commentModel == null)
    {
      return null;
    }
    commentModel.Content = updateCommentDto.Content;
    commentModel.Title = updateCommentDto.Title;
    await _context.SaveChangesAsync();
    return commentModel;
  }
}
