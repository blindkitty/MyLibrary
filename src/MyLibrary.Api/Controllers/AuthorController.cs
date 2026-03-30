using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.Contracts.Authors;
using MyLibrary.Api.Extensions;
using MyLibrary.Domain.Authors;

namespace MyLibrary.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateAuthorRequest request)
    {
        var authorId = await _authorService.CreateAsync(request.ToDto());
        return Ok(new CreateAuthorResponse(authorId));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAuthorRequest request)
    {
        var result = await _authorService.GetAsync(request.Id);
        return Ok(result.ToResponse());
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteAuthorRequest request)
    {
        await _authorService.DeleteAsync(request.Id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorRequest request)
    {
        await _authorService.UpdateAsync(request.ToDto());
        return Ok();
    }
}