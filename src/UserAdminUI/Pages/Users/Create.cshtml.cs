using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

namespace UserAdminUI.Pages.Users;

public class CreateModel : PageModel
{
    private readonly UserService _userService;

    [BindProperty]
    public UserViewModel User { get; set; } = new();

    [BindProperty]
    public string GroupIds { get; set; } = string.Empty;

    public CreateModel(UserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        User.GroupIds = GroupIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(Guid.Parse)
                                .ToList();

        await _userService.CreateUserAsync(User);
        return RedirectToPage("./Index");
    }
}