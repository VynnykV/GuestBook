using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.DAL.Context;

public class GuestBookContext: DbContext
{
    public DbSet<Post> Posts { get; private set; }
    public DbSet<Comment> Comments { get; private set; }

    public GuestBookContext(DbContextOptions<GuestBookContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Configure();
        modelBuilder.Seed();
    }
}