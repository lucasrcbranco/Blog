using Blog.API.Data;
using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Controllers;

[Route("api/v1/authors")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;
    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Author>> Get()
    {
        return await _context.Authors.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Author> GetById(Guid id)
    {
        return await _context.Authors.FirstAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Author Author)
    {
        try
        {
            await _context.Authors.AddAsync(Author);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] PutAuthorRequest request)
    {
        try
        {
            var authorToAlter = await _context.Authors.FirstAsync(p => p.Id == request.Id);

            authorToAlter.Update(request.title, request.content);

            _context.Authors.Update(authorToAlter);
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
            var Author = await _context.Authors.FirstAsync(p => p.Id == id);

            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}


public sealed record PutAuthorRequest(Guid Id, string author, string title, string content);