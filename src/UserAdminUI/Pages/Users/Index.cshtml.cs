using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

namespace UserAdminUI.Pages.Users;

public class IndexModel : PageModel
{
    private readonly UserService _userService;
    public List<UserViewModel> Users { get; set; } = new();

    public IndexModel(UserService userService)
    {
        _userService = userService;
    }

    public async Task OnGetAsync()
    {
        Users = await _userService.GetUsersAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return RedirectToPage();
    }
}