using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

namespace UserAdminUI.Pages.Users;

public class IndexModel : PageModel
{
    private readonly UserApiClient _users;

    public IndexModel(UserApiClient users)
    {
        _users = users;
    }

    public List<UserViewModel> Users { get; set; } = new();
    public int? TotalUserCount { get; set; }
    public Dictionary<string, int> UsersPerGroup { get; set; } = new();

    public async Task OnGetAsync()
    {
        Users = await _users.GetUsersAsync();
    }
    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _users.DeleteUserAsync(id);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostTotalCountAsync()
    {
        TotalUserCount = await _users.GetTotalUserCountAsync();
        await OnGetAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostCountPerGroupAsync()
    {
        UsersPerGroup = await _users.GetUserCountPerGroupAsync();
        await OnGetAsync();
        return Page();
    }
}