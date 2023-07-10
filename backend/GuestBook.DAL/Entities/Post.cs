using GuestBook.DAL.Entities.Abstract;

namespace GuestBook.DAL.Entities;

public sealed class Post: BaseEntity
{
    public string Author { get; set; }
    public string Body { get; set; }
    public ICollection<Comment> Comments { get; private set; }

    public Post()
    {
        Comments = new List<Comment>();
    }
}