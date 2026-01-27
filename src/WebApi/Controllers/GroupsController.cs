using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/groups")]
public class GroupsController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("with-users")]
    public async Task<IActionResult> GetGroupsWithUsers()
    {
        var result = await _groupService.GetGroupsWithUsersAsync();
        return Ok(result);
    }
}