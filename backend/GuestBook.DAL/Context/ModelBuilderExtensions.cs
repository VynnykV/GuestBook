using Bogus;
using GuestBook.Common.Constraints;
using GuestBook.DAL.Entities;
using GuestBook.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.DAL.Context;

public static class ModelBuilderExtensions
{
    public static void Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfig).Assembly);
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {
        Randomizer.Seed = new Random(100);

        var posts = GeneratePosts(10);
        var comments = GenerateComments(posts, 30);

        modelBuilder.Entity<Post>().HasData(posts);
        modelBuilder.Entity<Comment>().HasData(comments);
    }
    
    private static IList<Post> GeneratePosts(int count)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Post>()
            .RuleFor(x => x.Id, f => f.IndexGlobal)
            .RuleFor(x => x.Author, f => f.Person.FullName)
            .RuleFor(x => x.Body, f => f.Lorem.Text())
            .RuleFor(x => x.CreatedAt, f => f.Date.Recent())
            .FinishWith((x, p) =>
            {
                var l = p.Author;
                if (p.Author.Length > PostConstraints.AuthorMaxLength)
                    p.Author = p.Author.Substring(0, PostConstraints.AuthorMaxLength);
                if (p.Body.Length > PostConstraints.BodyMaxLength)
                    p.Body = p.Body.Substring(0, PostConstraints.BodyMaxLength);
            })
            .Generate(count);
    }
    
    private static IList<Comment> GenerateComments(IList<Post> posts, int count)
    {
        Faker.GlobalUniqueIndex = 0;

        return new Faker<Comment>()
            .RuleFor(x => x.Id, f => f.IndexGlobal)
            .RuleFor(x => x.Author, f => f.Person.FullName)
            .RuleFor(x => x.Body, f => f.Lorem.Text())
            .RuleFor(x => x.CreatedAt, f => f.Date.Recent())
            .RuleFor(x => x.PostId, f => f.PickRandom(posts).Id)
            .FinishWith((x, c) =>
            {
                if (c.Author.Length > CommentConstraints.AuthorMaxLength)
                    c.Author = c.Author.Substring(0, CommentConstraints.AuthorMaxLength);
                if (c.Body.Length > CommentConstraints.BodyMaxLength)
                    c.Body = c.Body.Substring(0, CommentConstraints.BodyMaxLength);
            })
            .Generate(count);
    }
}