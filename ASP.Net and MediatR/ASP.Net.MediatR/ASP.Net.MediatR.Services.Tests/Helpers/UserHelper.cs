using ASP.Net.MediatR.Contacts.Dto;

namespace ASP.Net.MediatR.Services.Tests.Helpers;

public class UserHelper : BaseHelper<Guid>
{
    public override IEnumerable<Guid> CreateIds() =>
        Enumerable.Range(1, 3).Select(x => Guid.NewGuid()).ToList();

    public UserDto CreateUser(Guid id) =>
        new UserDto
        {
            Id = id,
            Name = "Test data",
            Login = "Test login",
            Password = "Test password",
            RegisterDate = DateTime.UtcNow,
            RoleId = 1
        };

    public IEnumerable<UserDto> CreateUsers() =>
        Enumerable.Range(1, 3).Select(x => new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Test User",
            Login = "Test Login",
            Password = "Test Password",
            RegisterDate = DateTime.UtcNow,
            RoleId = 1
        }).ToList();

    public (Guid addedId, string oldPassword, UserDto userDto) CreateUserDataForAdd() 
    {
        var addedId = Guid.NewGuid();
        var oldPassword = "TestPassword";

        var userDto = new UserDto
        {
            Id = addedId,
            Login = "TestLogin",
            Name = "TestName",
            Password = oldPassword,
            RegisterDate = DateTime.UtcNow,
            RoleId = 1
        };

        return (addedId, oldPassword, userDto);
    }

    public (IEnumerable<Guid> ids, IEnumerable<UserDto> userDtos) CreateUsersDataForAdd()
    {
        var users = Enumerable.Range(1, 3).Select(x => new UserDto
        {
            Id = Guid.NewGuid(),
            Name = "Test User",
            Login = "Test Login",
            Password = "Test Password",
            RegisterDate = DateTime.UtcNow,
            RoleId = 1
        });

        return (users.Select(x => x.Id).ToList(), users.ToList());
    }
}
