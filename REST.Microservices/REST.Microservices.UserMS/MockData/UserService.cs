namespace REST.Microservices.UserMS.MockData;

public class UserService : IUserService
{
    private readonly static IEnumerable<User> users = new List<User>(new[]
    {
        new User { Id = 1, Email = "nick_132@mail.ua", Name = "Nick", Registred = DateTime.UtcNow.AddDays(-4) },
        new User { Id = 2, Email = "yura_suvarikin@gmail.com", Name = "Yura", Registred = DateTime.UtcNow },
        new User { Id = 3, Email = "rus_rusilev@gmail.com", Name = "Ruslan", Registred = DateTime.UtcNow.AddDays(-10) },
        new User { Id = 4, Email = "oleg_saksofonov@gmail.com", Name = "Oleh", Registred = DateTime.UtcNow.AddDays(-3) },
        new User { Id = 5, Email = "vadim_naumeiko@gmail.com", Name = "Vadim", Registred = DateTime.UtcNow.AddDays(-30) },
        new User { Id = 6, Email = "sisha_tegeschenko1488@gmail.com", Name = "Sisha", Registred = DateTime.UtcNow.AddDays(-5) }
    });

    public async Task<User> GetUser(int id) =>
        await Task.FromResult(users.FirstOrDefault(x => x.Id == id)!);

    public async Task<IEnumerable<User>> GetUsers() =>
        await Task.FromResult(users);
}

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
}