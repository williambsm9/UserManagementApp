using System.Net.Http.Json;
using UserAdminUI.Models;

namespace UserAdminUI.Services;

public class UserApiClient
{
    private readonly HttpClient _http;

    public UserApiClient(HttpClient http)
    {
        _http = http;
    }

    private const string ApiBase = "http://localhost:5001/api/users";

    public async Task<List<UserViewModel>> GetUsersAsync()
        => await _http.GetFromJsonAsync<List<UserViewModel>>(ApiBase) ?? new();

    public async Task<UserViewModel?> GetUserAsync(Guid id)
        => await _http.GetFromJsonAsync<UserViewModel>($"{ApiBase}/{id}");

    public async Task CreateUserAsync(UserViewModel user)
        => await _http.PostAsJsonAsync(ApiBase, user);

    public async Task UpdateUserAsync(UserViewModel user)
        => await _http.PutAsJsonAsync($"{ApiBase}/{user.Id}", user);

    public async Task DeleteUserAsync(Guid id)
        => await _http.DeleteAsync($"{ApiBase}/{id}");
}