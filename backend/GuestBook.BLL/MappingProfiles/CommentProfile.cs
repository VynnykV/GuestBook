using AutoMapper;
using GuestBook.Common.DTOs.Comment;
using GuestBook.DAL.Entities;

namespace GuestBook.BLL.MappingProfiles;

public sealed class CommentProfile: Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDTO>();
        CreateMap<CommentCreateDTO, Comment>();
    }
}