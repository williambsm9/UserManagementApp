namespace WebApi.IntegrationTests;

public class UsersApiTests
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public UsersApiTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateUser_AssignsGroups() { }

    [Fact]
    public async Task UpdateUser_ChangesGroups() { }

    [Fact]
    public async Task GetUsers_ReturnsUsersWithGroups() { }
}