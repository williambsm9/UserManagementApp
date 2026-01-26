using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupsController : ControllerBase
{
    private readonly IUserService _userService;

    public GroupsController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("with-users")]
    public async Task<IActionResult> GetGroupsWithUsers()
    {
        return Ok(await _userService.GetGroupsWithUsersAsync());
    }
}