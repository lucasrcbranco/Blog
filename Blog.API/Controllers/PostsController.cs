using Blog.API.Data;
using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Controllers;

[Route("api/v1/posts")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PostsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Post>> Get()
    {
        return await _context.Posts.Include(p => p.Author).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Post> GetById(Guid id)
    {
        return await _context.Posts.Include(p => p.Author).FirstAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Post post)
    {
        try
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PutPostRequest request)
    {
        try
        {
            var postToAlter = await _context.Posts.FirstAsync(p => p.Id == request.Id);

            postToAlter.Update(request.title, request.content);

            _context.Posts.Update(postToAlter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            var post = await _context.Posts.FirstAsync(p => p.Id == id);

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}


public sealed record PutPostRequest(Guid Id, string author, string title, string content);