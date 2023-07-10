using AutoMapper;
using GuestBook.BLL.Exceptions;
using GuestBook.BLL.Interfaces;
using GuestBook.BLL.Services.Abstract;
using GuestBook.Common.DTOs.Comment;
using GuestBook.DAL.Context;
using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.BLL.Services;

public sealed class CommentService: BaseService, ICommentService
{
    public CommentService(GuestBookContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<CommentDTO> CreateComment(CommentCreateDTO commentCreateDto)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(x => x.Id == commentCreateDto.PostId);
        if (existingPost is null)
            throw new NotFoundException(nameof(Post), commentCreateDto.PostId);
        
        var commentEntity = _mapper.Map<Comment>(commentCreateDto);

        _context.Comments.Add(commentEntity);
        await _context.SaveChangesAsync();

        var createdComment = await _context.Comments
            .FirstAsync(comment => comment.Id == commentEntity.Id);

        return _mapper.Map<CommentDTO>(createdComment);
    }
}