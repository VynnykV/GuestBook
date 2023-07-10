using FluentValidation;
using GuestBook.Common.Constraints;
using GuestBook.Common.DTOs.Comment;

namespace GuestBook.WebAPI.Validators;

public class CommentCreateDTOValidator: AbstractValidator<CommentCreateDTO>
{
    public CommentCreateDTOValidator()
    {
        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(CommentConstraints.AuthorMaxLength);
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(CommentConstraints.BodyMaxLength); 
    }
}