using FluentValidation;
using GuestBook.Common.Constraints;
using GuestBook.Common.DTOs.Post;

namespace GuestBook.WebAPI.Validators;

public class PostCreateDTOValidator: AbstractValidator<PostCreateDTO>
{
    public PostCreateDTOValidator()
    {
        RuleFor(x => x.Author)
            .NotEmpty()
            .MaximumLength(PostConstraints.AuthorMaxLength);
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(PostConstraints.BodyMaxLength);
    }
}