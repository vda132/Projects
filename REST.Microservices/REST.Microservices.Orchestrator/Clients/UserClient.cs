using REST.Microservices.Orchestrator.Contracts;

namespace REST.Microservices.Orchestrator.Clients;

public class UserClient : IUserClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<UserClient> _logger;

    public UserClient(IHttpClientFactory httpClientFactory, ILogger<UserClient> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<User> GetUser(int id, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("UserClient");
            var response = await client.GetFromJsonAsync<User>($"/users/{id}", cancellationToken);

            return response!;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogInformation(ex.Message);
            return null!;
        }
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("UserClient");

        var response = await client.GetFromJsonAsync<IEnumerable<User>>("/users", cancellationToken);
        return response!.ToList();
    }
}

public interface IUserClient
{
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetUser(int id, CancellationToken cancellationToken);
}