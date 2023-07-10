using AutoMapper;
using GuestBook.Common.DTOs.Post;
using GuestBook.DAL.Entities;

namespace GuestBook.BLL.MappingProfiles;

public sealed class PostProfile: Profile
{
    public PostProfile()
    {
        CreateMap<Post, PostDTO>();
        CreateMap<PostCreateDTO, Post>();
    }
}