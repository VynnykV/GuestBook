using GuestBook.Common.DTOs.Comment;

namespace GuestBook.BLL.Interfaces;

public interface ICommentService
{
    Task<CommentDTO> CreateComment(CommentCreateDTO commentCreateDto);
}