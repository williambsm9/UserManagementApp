using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

namespace UserAdminUI.Pages.Users;

public class EditModel : PageModel
{
    private readonly UserApiClient _users;
    private readonly GroupApiClient _groups;

    public EditModel(UserApiClient users, GroupApiClient groups)
    {
        _users = users;
        _groups = groups;
    }

    [BindProperty]
    public UserViewModel User { get; set; } = new();

    public List<GroupViewModel> Groups { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var user = await _users.GetUserAsync(id);
        if (user == null)
            return NotFound();

        User = user;
        Groups = await _groups.GetGroupsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Groups = await _groups.GetGroupsAsync();
            return Page();
        }

        await _users.UpdateUserAsync(User);
        return RedirectToPage("Index");
    }
}