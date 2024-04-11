using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Contracts;
using PetFamily.Domain;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreatePostRequest request, [FromQuery] int size, CancellationToken ct)
    {
        var post = new Post(
            request.Name,
            request.Breed,
            request.Height,
            request.Vaccine,
            request.BirthDate,
            request.Photo,
            request.Description,
            request.Adress);

        return Ok();
    }
}