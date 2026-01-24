using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, string email)
    {
        var id = await _userService.CreateUserAsync(name, email);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, string name, string email)
    {
        await _userService.UpdateUserAsync(id, name, email);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }

    [HttpGet("count")]
    public async Task<IActionResult> TotalCount()
    {
        return Ok(await _userService.GetTotalUserCountAsync());
    }

    [HttpGet("count-per-group")]
    public async Task<IActionResult> CountPerGroup()
    {
        return Ok(await _userService.GetUserCountPerGroupAsync());
    }
}