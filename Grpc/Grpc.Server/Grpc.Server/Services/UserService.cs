using Grpc.Core;
using Grpc.Server.Converter;

namespace Grpc.Server.Services;

public class UserService : Server.User.UserBase
{
    private readonly static IEnumerable<User> users = new List<User>(new User[]
    {
        new User { Id = 1, Name = "Sisha", RegisterDate = DateTime.UtcNow.AddDays(-3), Age = 19 },
        new User { Id = 2, Name = "Rus", RegisterDate = DateTime.UtcNow.AddDays(-10), Age = 20 },
        new User { Id = 3, Name = "Yura", RegisterDate = DateTime.UtcNow, Age = 19 },
        new User { Id = 4, Name = "Vova", RegisterDate = DateTime.UtcNow.AddDays(-12), Age = 19 }
    });

    public override async Task<UserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var user = users.FirstOrDefault(x => x.Id == request.Id);

        return await Task.FromResult(user is null ? null! : UserToResponseConverter.ToUserResponse(user!));
    }

    public override async Task<UsersResponse> GetUsers(GetUsersRequest request, ServerCallContext context)
    {
        var response = new UsersResponse();
        foreach (var user in users)
        {
            response.Users.Add(UserToResponseConverter.ToUserResponse(user));
        }

        return await Task.FromResult(response);
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
}

