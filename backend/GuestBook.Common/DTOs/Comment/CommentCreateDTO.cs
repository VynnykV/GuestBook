namespace GuestBook.Common.DTOs.Comment;

public sealed class CommentCreateDTO
{
    public int PostId { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
}