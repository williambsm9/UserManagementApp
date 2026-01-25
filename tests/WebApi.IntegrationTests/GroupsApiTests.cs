namespace WebApi.IntegrationTests;

public class GroupsApiTests
    : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public GroupsApiTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetGroups_ReturnsGroupsWithUsers() { }
}