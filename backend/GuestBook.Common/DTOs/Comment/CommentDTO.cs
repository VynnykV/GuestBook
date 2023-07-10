namespace GuestBook.Common.DTOs.Comment;

public sealed class CommentDTO
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
}