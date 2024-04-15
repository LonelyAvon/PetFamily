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
    private readonly PetFamilyDbContext _dbContext;

    public PostController(PetFamilyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePostRequest request, CancellationToken ct)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var pets = await _dbContext.Pets.ToListAsync();
        
        return Ok(pets);
    }
}