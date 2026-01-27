using System.Net;
using System.Net.Http.Json;
using Application.DTOs.Group;
using WebApi.IntegrationTests;
using Xunit;

public class GroupEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public GroupEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetGroupsWithUsers_ShouldReturnGroupsWithUsers()
    {
        var response = await _client.GetAsync("/api/groups/with-users");

        response.EnsureSuccessStatusCode();

        var groups = await response.Content.ReadFromJsonAsync<List<GroupWithUsersDto>>();

        Assert.NotNull(groups);
        Assert.NotEmpty(groups);
    }

    [Fact]
    public async Task GetUsersForNonExistingGroup_ShouldReturnNotFound()
    {
        var response = await _client.GetAsync("/api/groups/999/users");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}