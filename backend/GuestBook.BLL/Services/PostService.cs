using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GuestBook.BLL.Interfaces;
using GuestBook.BLL.Services.Abstract;
using GuestBook.Common.DTOs.Post;
using GuestBook.DAL.Context;
using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.BLL.Services;

public class PostService: BaseService, IPostService
{
    public PostService(
        GuestBookContext context, 
        IMapper mapper) : base(context, mapper)
    { }

    public async Task<ICollection<PostDTO>> GetAll(Expression<Func<Post, bool>>? predicate = null)
    {
        IQueryable<Post> posts = _context.Posts;

        if (predicate != null)
        {
            posts = posts.Where(predicate);
        }

        return await posts
            .ProjectTo<PostDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}