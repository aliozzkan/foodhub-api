using System;
using foodhubapi.Dtos.Comment;
using foodhubapi.Models;

namespace foodhubapi.Interfaces;

public interface ICommentRepository
{
  Task<List<Comment>> GetAllAsync();
  Task<Comment?> GetByIdAsync(int id);
  Task<Comment> CreateAsync(Comment comment);
  Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateCommentDto);
  Task<Comment?> DeleteAsync(int id);


}
