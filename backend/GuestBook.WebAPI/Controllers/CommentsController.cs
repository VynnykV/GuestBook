using GuestBook.BLL.Interfaces;
using GuestBook.Common.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<ActionResult<CommentDTO>> CreateComment([FromBody] CommentCreateDTO dto)
    {
        return Ok(await _commentService.CreateComment(dto));
    }
}