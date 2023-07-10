using GuestBook.Common.DTOs.Post;

namespace GuestBook.BLL.Interfaces;

public interface IPostService
{
    Task<ICollection<PostDTO>> GetAll();
    Task<PostDTO> CreatePost(PostCreateDTO postCreateDto);
}