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

    public async Task OnGetAsync()
    {
        Users = await _users.GetUsersAsync();
    }
    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _users.DeleteUserAsync(id);
        return RedirectToPage();
    }
}