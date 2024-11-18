using System;
using System.ComponentModel.DataAnnotations;

namespace foodhubapi.Dtos.Comment;

public class CreateCommentDto
{
  [Required]
  [MinLength(5, ErrorMessage = "Title must be at least 5 characters")]
  [MaxLength(250, ErrorMessage = "Title must be at most 250 characters")]
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
}
