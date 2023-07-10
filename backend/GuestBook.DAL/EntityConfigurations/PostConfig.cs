using GuestBook.Common.Constraints;
using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuestBook.DAL.EntityConfigurations;

public class PostConfig: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Author)
            .HasMaxLength(PostConstraints.AuthorMaxLength)
            .IsRequired();
        builder.Property(x => x.Body)
            .HasMaxLength(PostConstraints.BodyMaxLength)
            .IsRequired();

        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}