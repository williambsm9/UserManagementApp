using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

namespace UserAdminUI.Pages.Users;

public class EditModel : PageModel
{
    private readonly UserService _userService;

    [BindProperty]
    public UserViewModel User { get; set; } = new();

    [BindProperty]
    public string GroupIds { get; set; } = string.Empty;

    public EditModel(UserService userService) => _userService = userService;

    public async Task OnGetAsync(Guid id)
    {
        var existing = await _userService.GetUserAsync(id);
        if (existing != null)
        {
            User = existing;
            GroupIds = string.Join(",", User.GroupIds);
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        User.GroupIds = GroupIds.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                .Select(Guid.Parse)
                                .ToList();

        await _userService.UpdateUserAsync(User);
        return RedirectToPage("./Index");
    }
}