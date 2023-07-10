using GuestBook.BLL.Interfaces;
using GuestBook.Common.DTOs.Post;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<PostDTO>>> GetAllPosts()
    {
        var posts = await _postService.GetAll();
        return Ok(posts);
    }
    
    [HttpPost]
    public async Task<ActionResult<PostDTO>> CreatePost([FromBody] PostCreateDTO dto)
    {
        return Ok(await _postService.CreatePost(dto));
    }
}