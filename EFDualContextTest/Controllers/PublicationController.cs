using EFDualContextTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFDualContextTest.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicationController : ControllerBase
{
    private readonly PublicationService _publicationService;

    public PublicationController(PublicationService publicationService)
    {
        _publicationService = publicationService;
    }
    [HttpPost("Authors")]
    public async Task<ActionResult> AddAuthors()
    {
        await _publicationService.AddAuthors();
        return Ok();
    }
    
    [HttpPost("Books")]
    public async Task<ActionResult> AddBooks()
    {
        await _publicationService.AddBooks();
        return Ok();
    }
    
    [HttpPatch("Books/Author")]
    public async Task<ActionResult> AssignBooks()
    {
        await _publicationService.AssignBooks();
        return Ok();
    }
    
    [HttpPut("Books/Author")]
    public async Task<ActionResult> ReassignBooks()
    {
        await _publicationService.ReassignBooks();
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAuthers()
    {
        var t = await _publicationService.GetAuthersAsyc();
        return Ok(t);
    }
}