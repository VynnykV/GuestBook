﻿using GuestBook.Common.DTOs.Comment;

namespace GuestBook.Common.DTOs.Post;

public sealed class PostDTO
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<CommentDTO> Comments { get; set; }
}