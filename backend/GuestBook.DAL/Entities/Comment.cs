using GuestBook.DAL.Entities.Abstract;

namespace GuestBook.DAL.Entities;

public sealed class Comment: BaseEntity
{
    public string Author { get; set; }
    public string Body { get; set; }
    public int PostId { get; set; }
    public Post Post { get; private set; }
}