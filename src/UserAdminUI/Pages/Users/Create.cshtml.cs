using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserAdminUI.Models;
using UserAdminUI.Services;

public class CreateModel : PageModel
{
    private readonly UserApiClient _users;
    private readonly GroupApiClient _groups;

    public CreateModel(UserApiClient users, GroupApiClient groups)
    {
        _users = users;
        _groups = groups;
    }

    [BindProperty]
    public UserViewModel User { get; set; } = new();

    public List<GroupViewModel> Groups { get; set; } = new();

    public async Task OnGetAsync()
    {
        Groups = await _groups.GetGroupsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Groups = await _groups.GetGroupsAsync();
            return Page();
        }

        await _users.CreateUserAsync(User);
        return RedirectToPage("Index");
    }
}