using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFamily.API.Contracts;
using PetFamily.Domain;
using PetFamily.Infrastructure;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ApplicationContext _dbContext;

    public PostController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePostRequest request, [FromQuery] int size, CancellationToken ct)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}