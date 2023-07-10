using GuestBook.Common.Constraints;
using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuestBook.DAL.EntityConfigurations;

public class CommentConfig: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Author)
            .HasMaxLength(CommentConstraints.AuthorMaxLength)
            .IsRequired();
        builder.Property(x => x.Body)
            .HasMaxLength(CommentConstraints.BodyMaxLength)
            .IsRequired();
    }
}