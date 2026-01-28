using System.Net.Http.Json;
using UserAdminUI.Models;

public class GroupApiClient
{
    private readonly HttpClient _http;

    public GroupApiClient(HttpClient http)
    {
        _http = http;
    }

    private const string ApiBase = "http://localhost:5001/api/groups";

    public async Task<List<GroupViewModel>> GetGroupsAsync()
        => await _http.GetFromJsonAsync<List<GroupViewModel>>(ApiBase)
           ?? new();
}