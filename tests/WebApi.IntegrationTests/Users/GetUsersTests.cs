using System.Net;
using System.Net.Http.Json;
using Application.DTOs.User;

namespace WebApi.IntegrationTests.Users;

public class GetUsersTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public GetUsersTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetUsers_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        Console.WriteLine($"Response status: {response.StatusCode}");
        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var users = await response.Content
            .ReadFromJsonAsync<List<UserWithGroupsDto>>();

        Assert.NotNull(users);
        Assert.Empty(users);
    }
}