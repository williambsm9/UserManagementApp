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
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        var id = await _userService.CreateUserAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        await _userService.UpdateUserAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetUsersWithGroupsAsync());
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