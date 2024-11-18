using System;
using foodhubapi.Dtos.Comment;
using foodhubapi.Models;
using Npgsql.Replication;

namespace foodhubapi.Mappers;

public static class CommentMappers
{
  public static CommentDto ToCommentDto(this Comment comment)
  {
    return new CommentDto
    {
      Id = comment.Id,
      Title = comment.Title,
      Content = comment.Content,
      CreatedOn = comment.CreatedOn,
      CreatedBy = comment.AppUser.UserName,
      StockId = comment.StockId
    };
  }

  public static Comment ToCommentFromCreateDto(this CreateCommentDto commentDto, int stockId)
  {
    return new Comment
    {
      StockId = stockId,
      Title = commentDto.Title,
      Content = commentDto.Content
    };
  }

}
