using AutoMapper;
using GuestBook.BLL.Interfaces;
using GuestBook.BLL.Services.Abstract;
using GuestBook.Common.DTOs.Post;
using GuestBook.DAL.Context;
using GuestBook.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.BLL.Services;

public sealed class PostService: BaseService, IPostService
{
    public PostService(
        GuestBookContext context, 
        IMapper mapper) : base(context, mapper)
    { }

    public async Task<ICollection<PostDTO>> GetAll()
    {
        var posts = await _context.Posts
            .Include(x => x.Comments)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        return _mapper.Map<ICollection<PostDTO>>(posts);
    }

    public async Task<PostDTO> CreatePost(PostCreateDTO postCreateDto)
    {
        var postEntity = _mapper.Map<Post>(postCreateDto);
        
        _context.Posts.Add(postEntity);
        await _context.SaveChangesAsync();
        
        var createdPost = await _context.Posts
            .FirstAsync(post => post.Id == postEntity.Id);

        var createdPostDTO = _mapper.Map<PostDTO>(createdPost);

        return createdPostDTO;
    }
}