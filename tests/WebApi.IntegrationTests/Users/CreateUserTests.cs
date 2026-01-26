using System.Net;
using System.Net.Http.Json;
using WebApi.IntegrationTests;
using Xunit;

public class CreateUserTests
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CreateUserTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateUser_ReturnsCreatedAndGuid()
    {
    var request = new
    {
    Name = "John",
    Email = "john@test.com",
    GroupIds = new[] { Guid.NewGuid() }
    };


    var response =
    await _client.PostAsJsonAsync("/api/users", request);


    Assert.Equal(HttpStatusCode.Created, response.StatusCode);


    var id = await response.Content.ReadFromJsonAsync<Guid>();


    Assert.NotEqual(Guid.Empty, id);
    }
}