using Application.DTOs.User;
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
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var id = await _userService.CreateUserAsync(dto);
        return CreatedAtAction(nameof(Create), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
    {
        await _userService.UpdateUserAsync(id, dto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
    var users = await _userService.GetAllAsync();
    return Ok(users);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }

    [HttpGet("count")]
    public async Task<int> TotalCount()
        => await _userService.GetTotalUserCountAsync();

    [HttpGet("count-per-group")]
    public async Task<Dictionary<string, int>> CountPerGroup()
        => await _userService.GetUserCountPerGroupAsync();
}