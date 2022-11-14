using Grpc.Client.Converter;
using Grpc.Net.Client;
using Grpc.Server;

namespace Grpc.Client.GrpcClientService;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly Server.User.UserClient _client;
    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
        var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
        _client = new Server.User.UserClient(channel);
    }

    public async Task<User> GetUserAsync(int id)
    {
        var request = new GetUserRequest { Id = id };

        try
        {
            var response = await _client.GetUserAsync(request);
            return response is null ? null! : UserResponseToUserConverter.ToUser(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Couldnot call GRPC Server {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var request = new GetUsersRequest();
        var users = new List<User>();
        
        try
        {
            var response = _client.GetUsers(request);

            foreach (var user in response.Users)
                users.Add(UserResponseToUserConverter.ToUser(user));

            return await Task.FromResult(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Couldnot call GRPC Server {ex.Message}");
            return null!;
        }
    }
}

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserAsync(int id);
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
}