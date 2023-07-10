using System.Linq.Expressions;
using GuestBook.Common.DTOs.Post;
using GuestBook.DAL.Entities;

namespace GuestBook.BLL.Interfaces;

public interface IPostService
{
    Task<ICollection<PostDTO>> GetAll(Expression<Func<Post, bool>>? predicate = null);
    Task<PostDTO> CreatePost(PostCreateDTO postCreateDto);
}