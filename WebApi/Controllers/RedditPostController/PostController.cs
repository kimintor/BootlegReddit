using Microsoft.AspNetCore.Mvc;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebApi.Controllers.RedditPostController;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<RedditPost>> CreateAsync([FromBody] PostCreationDto dto)
    {
        try
        {
            RedditPost redditPost = await postLogic.CreateAsync(dto);
            return Created($"/post/{redditPost.Id}", redditPost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
    }

    [HttpGet] 
    public async Task<ActionResult<IEnumerable<PostTitleDto>>> GetTitlesAsync() {
        try
        {
            IEnumerable<PostTitleDto> result = await postLogic.GetPostTitles();
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}