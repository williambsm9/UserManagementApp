using System.Net;
using System.Net.Http.Json;
using WebApi.IntegrationTests;

public class UpdateUserTests
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public UpdateUserTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task UpdateUser_ReturnsNoContent_WhenUserExists()
    {
        // Create user first
        var createRequest = new
        {
            Name = "Jane",
            Email = "jane@test.com",
            GroupIds = new[] { Guid.NewGuid() }
        };

        var createResponse =
            await _client.PostAsJsonAsync("/api/users", createRequest);

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

        var userId =
            await createResponse.Content.ReadFromJsonAsync<Guid>();

        // Update
        var updateRequest = new
        {
            Name = "Jane Updated",
            Email = "jane.updated@test.com",
            GroupIds = new[] { Guid.NewGuid() }
        };

        var updateResponse =
            await _client.PutAsJsonAsync(
                $"/api/users/{userId}",
                updateRequest
            );

        Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
    }

    [Fact]
    public async Task UpdateUser_ReturnsNotFound_WhenUserDoesNotExist()
    {
        var request = new
        {
            Name = "Ghost",
            Email = "ghost@test.com",
            GroupIds = new[] { Guid.NewGuid() }
        };

        var response =
            await _client.PutAsJsonAsync(
                $"/api/users/{Guid.NewGuid()}",
                request
            );

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}